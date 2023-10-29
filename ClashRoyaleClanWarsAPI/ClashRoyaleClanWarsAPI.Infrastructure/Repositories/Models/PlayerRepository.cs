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

    public async Task<bool> ExistsCollection(int playerId, int cardId)
    {
        return await _context.Collection.FindAsync(playerId, cardId) is not null;
    }

    public async Task AddChallengeResult(int playerId, int challengeId, int reward)
    {
        var player = await GetSingleByIdAsync(playerId);
        
        var challenge = await _challengeRepository.GetSingleByIdAsync(challengeId);

        if (!challenge!.IsOpen) throw new ChallengeClosedException();

        var challengePlayerResult = ChallengePlayersModel.Create(player!, challenge, reward);

        await _context.ChallengePlayers.AddAsync(challengePlayerResult);
        
        await Save();
    }

    public async Task AddDonation(int playerId, int clanId, int cardId, int amount)
    {
        var player = await GetSingleByIdAsync(playerId);
        var clan = await _clanRepository.Value.GetSingleByIdAsync(clanId);
        var card = await _cardRepository.GetSingleByIdAsync(cardId);

        if(!player!.HaveCard(cardId)) throw new PlayerNotHaveCardException();
        
        _= await _context.ClanPlayers.FindAsync(playerId, clanId) ?? throw new IdNotFoundException<int>(playerId, clanId);

        var donation = DonationModel.Create(player, clan!, card!, amount);

        await _context.Donations.AddAsync(donation);

        await Save();
    }
}
