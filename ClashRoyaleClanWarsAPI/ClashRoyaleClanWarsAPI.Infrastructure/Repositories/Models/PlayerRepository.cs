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

namespace ClashRoyaleClanWarsAPI.Infrastructure.Repositories.Models;

internal class PlayerRepository : BaseRepository<PlayerModel, int>, IPlayerRepository
{
    private readonly IChallengeRepository _challengeRepository;
    private readonly ICardRepository _cardRepository;
    private readonly Lazy<IClanRepository> _clanRepository;
    private readonly IMapper _mapper;

    public PlayerRepository(ClashRoyaleDbContext context,
                            IChallengeRepository challengeRepository,
                            ICardRepository cardRepository,
                            Lazy<IClanRepository> clanRepository,
                            IMapper mapper) : base(context)
    {
        _challengeRepository = challengeRepository;
        _cardRepository = cardRepository;
        _clanRepository = clanRepository;
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

    public async Task UpdateAlias(int playerId, string alias)
    {
        var player = await GetSingleByIdAsync(playerId);

        player!.ChangeAlias(alias!);

        await Save();
    }

    public async Task AddPlayerChallenge(int playerId, int challengeId, int reward)
    {
        var challenge = await _challengeRepository.GetSingleByIdAsync(challengeId);

        if (!challenge!.IsOpen) throw new ChallengeClosedException();

        var player = await GetSingleByIdAsync(playerId);

        var playerChallenge = ChallengePlayersModel.Create(player!, challenge, 0);

        await _context.PlayerChallenges.AddAsync(playerChallenge);

        await Save();
    }
    public async Task AddPlayerChallengeResult(int playerId, int challengeId, int reward)
    {
        if (!await ExistsPlayerChallenge(playerId, challengeId))
            throw new IdNotFoundException<int>(playerId, challengeId);

        var playerChallenge = await _context.PlayerChallenges.FindAsync(playerId, challengeId);

        playerChallenge!.AddPrize(reward);
        playerChallenge!.Completed();

        _context.Entry(playerChallenge).State = EntityState.Modified;

        await Save();
    }

    public async Task AddDonation(int playerId, int clanId, int cardId, int amount)
    {
        var player = await GetSingleByIdAsync(playerId, true);
        var clan = await _clanRepository.Value.GetSingleByIdAsync(clanId);
        var card = await _cardRepository.GetSingleByIdAsync(cardId);

        if (!player!.HaveCard(cardId))
            throw new PlayerNotHaveCardException();

        if (!await ExistsClanPlayer(playerId, clanId))
            throw new IdNotFoundException<int>(playerId, clanId);

        if (await ExistsDonation(playerId, clanId, cardId, DateTime.Now))
            throw new DuplicationIdException(playerId, clanId, cardId);

        var donation = DonationModel.Create(player, clan!, card!, amount);

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
