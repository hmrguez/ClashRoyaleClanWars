using AutoMapper;
using AutoMapper.QueryableExtensions;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;
using ClashRoyaleClanWarsAPI.Domain.Exceptions;
using ClashRoyaleClanWarsAPI.Domain.Exceptions.Models;
using ClashRoyaleClanWarsAPI.Domain.Models;
using ClashRoyaleClanWarsAPI.Domain.Models.Card;
using ClashRoyaleClanWarsAPI.Domain.Relationships;
using ClashRoyaleClanWarsAPI.Infrastructure.Persistance;
using ClashRoyaleClanWarsAPI.Infrastructure.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ClashRoyaleClanWarsAPI.Infrastructure.Repositories.Models;

internal class PlayerRepository : BaseRepository<PlayerModel, int>, IPlayerRepository
{
    private readonly IChallengeRepository _challengeRepository;
    private readonly ICardRepository _cardRepository;
    private readonly IMapper _mapper;

    public PlayerRepository(ClashRoyaleDbContext context,
                            IChallengeRepository challengeRepository,
                            ICardRepository cardRepository,
                            IMapper mapper) : base(context)
    {
        _challengeRepository = challengeRepository;
        _cardRepository = cardRepository;
        _mapper = mapper;
    }

    public async Task<PlayerModel> GetSingleByIdAsync(int id, bool fullLoad = false)
    {

        var player = fullLoad ? await _context.Players
                                            .Include(p => p.FavoriteCard)?
                                            .Include(p => p.Cards)!
                                            .ThenInclude(c => c.Card)
                                            .ProjectTo<PlayerModel>(_mapper.ConfigurationProvider)
                                            .Where(p => p.Id == id)
                                            .FirstOrDefaultAsync()!
                                            ?? throw new IdNotFoundException<int>(id)
                                        :
                                         await base.GetSingleByIdAsync(id);

        return player!;
    }

    public async Task AddCard(int playerId, int cardId)
    {
        var player = await GetSingleByIdAsync(playerId);

        var card = await _cardRepository.GetSingleByIdAsync(cardId);

        if (await ExistsCollection(playerId, cardId)) throw new DuplicationIdException(playerId, cardId);

        player!.AddCard(card!);

        player.AddFavoriteCard(card);

        await Save();
    }

    public async Task<IEnumerable<CardModel>> GetAllCardsOfPlayerAsync(int playerId)
    {
        var player = await GetSingleByIdAsync(playerId, true);

        return player!.Cards?.Select(c => c.Card)!;
    }

    public async Task<IEnumerable<PlayerModel>> GetPlayersByAliasAsync(string alias)
    {
        return (await GetAllAsync()).Where(c => c.Alias == alias);
    }

    public override async Task Update(PlayerModel model)
    {
        var player = await GetSingleByIdAsync(model.Id);

        if (await _context.Users.Where(u => u.UserName == model.Alias).FirstOrDefaultAsync() is not null)
            throw new DuplicateNameException();

        player.AssignElo(model.Elo);
        player.ChangeAlias(model.Alias!);
        player.Level = model.Level;

        _context.Entry(player).Reference(u=> u.User).Load();

        if (player.User != null)
            player.User.UserName = model.Alias!;

        _context.Entry(player).State = EntityState.Modified;

        await Save();
    }

    public override async Task Delete(PlayerModel model)
    {
        var clanWar = await _context.ClanPlayers
            .Include(cp=> cp.Clan)
            .Where(cp => cp.Player!.Id == model.Id).FirstOrDefaultAsync();

        if (clanWar != null)
            clanWar.Clan!.RemoveAmountMember();

        await _context.ClanPlayers.Where(cp=> cp.Player!.Id == model.Id).ExecuteDeleteAsync();
        await _context.PlayerChallenges.Where(cp=> cp.Player!.Id == model.Id).ExecuteDeleteAsync();
        await _context.Battles.Where(b=> b.Winner!.Id == model.Id || b.Loser!.Id == model.Id).ExecuteDeleteAsync();
        await _context.Players.Where(p=> p.Id == model.Id).ExecuteDeleteAsync();

        await Save();

    }
    
    public async Task UpdateAlias(int playerId, string alias)
    {
        var player = await GetSingleByIdAsync(playerId);

        _context.Entry(player).Reference(u => u.User).Load();


        if (player.User != null)
        {
            if (await _context.Users.Where(u => u.UserName == alias && u.Id != player.User.Id).FirstOrDefaultAsync() is not null)
                throw new DuplicateNameException();

            player.User.UserName = alias;
        }

        player!.ChangeAlias(alias!);

        await Save();
    }

    public async Task AddPlayerChallenge(int playerId, int challengeId, int reward)
    {
        var challenge = await _challengeRepository.GetSingleByIdAsync(challengeId);

        if (await ExistsChallengePlayer(playerId, challengeId))
            throw new DuplicationIdException(playerId, challengeId);

        if (!challenge!.IsOpen) 
            throw new ChallengeClosedException();

        var player = await GetSingleByIdAsync(playerId);

        if (player.Level < challenge.MinLevel)
            throw new PlayerHasNoEnoughLevelException(challenge.MinLevel, player.Level);

        var playerChallenge = ChallengePlayersModel.Create(player!, challenge, reward);

        await _context.PlayerChallenges.AddAsync(playerChallenge);

        player.UpdateElo(reward);

        _context.Entry(player).State = EntityState.Modified;
        
        await Save();
    }
    
    public async Task<bool> ExistsChallengePlayer(int playerId, int challengeId)
    {
        return (await _context.PlayerChallenges.FindAsync(playerId, challengeId)) is not null;
    }
    
    public async Task AddPlayerChallengeResult(int playerId, int challengeId, int reward)
    {
        if (!await ExistsPlayerChallenge(playerId, challengeId))
            throw new IdNotFoundException<int>(playerId, challengeId);

        var player = await GetSingleByIdAsync(playerId);

        var playerChallenge = await _context.PlayerChallenges.FindAsync(playerId, challengeId);

        player.UpdateElo(reward);

        _context.Entry(player).State = EntityState.Modified;

        playerChallenge!.AddPrize(reward);
        playerChallenge!.Completed();

        _context.Entry(playerChallenge).State = EntityState.Modified;

        await Save();
    }

    public async Task AddDonation(int playerId, int cardId, int amount, DateTime date)
    {
        var clanPlayer = await _context.ClanPlayers
            .Where(cp => cp.Player!.Id == playerId)
            .Include(cp=> cp.Clan)
            .Include(cp=> cp.Player)
            .ThenInclude(cp=> cp!.Cards)
            .FirstOrDefaultAsync() 
            ?? throw new PlayerHasNoClanException(playerId);

        var player = clanPlayer.Player;
        var clan = clanPlayer.Clan;

        var card = await _cardRepository.GetSingleByIdAsync(cardId);

        if (!player!.HaveCard(cardId))
            throw new PlayerNotHaveCardException();

        if (await ExistsDonation(playerId, clan!.Id, cardId, date))
            throw new DuplicationIdException(playerId, clan.Id, cardId);

        if (_context.Entry(player).State == EntityState.Detached)
            _context.Attach(player);

        var donation = DonationModel.Create(player, clan!, card!, amount, date);

        await _context.Donations.AddAsync(donation);

        await Save();
    }

    public async Task<bool> ExistsPlayerChallenge(int playerId, int challengeId)
    {
        return await _context.PlayerChallenges.FindAsync(playerId, challengeId) is not null;
    }

    public async Task<bool> ExistsCollection(int playerId, int cardId)
    {
        return await _context.Collection.FindAsync(playerId, cardId) is not null;
    }

    public async Task<bool> ExistsClanPlayer(int playerId, int clanId)
    {
        return await _context.ClanPlayers.FindAsync(playerId, clanId) is not null;
    }

    public async Task<bool> ExistsDonation(int playerId, int clanId, int cardId, DateTime date)
    {
        return await _context.Donations.FindAsync(playerId, clanId, cardId, date) is not null;
    }
}
