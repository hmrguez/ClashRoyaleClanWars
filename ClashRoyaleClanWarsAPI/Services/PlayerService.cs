using AutoMapper;
using AutoMapper.QueryableExtensions;
using ClashRoyaleClanWarsAPI.Data;
using ClashRoyaleClanWarsAPI.Dtos.CollectDto;
using ClashRoyaleClanWarsAPI.Dtos.PlayerDto;
using ClashRoyaleClanWarsAPI.Exceptions;
using ClashRoyaleClanWarsAPI.Interfaces.ServicesInterfaces;
using ClashRoyaleClanWarsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClashRoyaleClanWarsAPI.Services
{
    public class PlayerService : BaseService<PlayerModel>, IPlayerService
    {
        private readonly ICardService _cardService;
        private readonly IMapper _mapper;

        public PlayerService(DataContext context, ICardService cardService, IMapper mapper) : base(context)
        {
            _cardService = cardService;
            _mapper = mapper;
        }

        public async Task<PlayerModel> GetSingleByIdAsync(int id, bool fullLoad)
        {
            if (_context.Players == null) throw new ModelNotFoundException<PlayerModel>();

            PlayerModel? player = fullLoad? _context.Players
                                                .Include(p=>p.FavoriteCard)
                                                .Include(p => p.Cards)
                                                .ThenInclude(c => c.Card)
                                                .ProjectTo<PlayerModel>(_mapper.ConfigurationProvider)
                                                .Where(p => p.Id == id)
                                                .First() 
                                            : 
                                             await base.GetSingleByIdAsync(id);

            return player ?? throw new IdNotFoundException<PlayerModel>(id);
        }

        public override async Task Delete(int id)
        {
            if (_context.Players == null) throw new ModelNotFoundException<PlayerModel>();

            PlayerModel player = null!;

            try
            {
                player = await GetSingleByIdAsync(id, true);
            }
            catch (IdNotFoundException<PlayerModel>)
            {
                throw;
            }
            player.Cards.Clear();
            _context.Players.Remove(player);
            await Save();

        }
        
        public async Task AddCard(int playerId, int cardId)
        {
            if (_context.Players == null) throw new ModelNotFoundException<PlayerModel>();
            if (_context.Cards == null) throw new ModelNotFoundException<CardModel>();

            var player = await GetSingleByIdAsync(playerId);
            var card = await _cardService.GetSingleByIdAsync(cardId);

            player.Cards ??= new List<CollectModel>();
            
            var collect = new CollectModel
            {
                Player = player,
                Card = card,
                Level = card.InitialLevel,
                Date = DateTime.UtcNow
            };
            await _context.Collection.AddAsync(collect);

            await Save();
        }

        public async Task<IEnumerable<CardModel>> GetAllCardsOfPlayerAsync(int id)
        {
            if(_context.Players == null) throw new ModelNotFoundException<PlayerModel>();

            
            PlayerModel player = await GetSingleByIdAsync(id, true);

            
            return player.Cards.Select(c=>c.Card);

        }

        public async Task<IEnumerable<PlayerModel>> GetPlayersByAliasAsync(string alias)
        {
            if (_context.Players == null) throw new ModelNotFoundException<PlayerModel>();

            return (await GetAllAsync()).Where(c=>c.Alias == alias);

        }

        public async Task<PlayerModel> UpdateAlias(int playerId, string alias)
        {
            if (_context.Players == null) throw new ModelNotFoundException<PlayerModel>();

            var player = await GetSingleByIdAsync(playerId);
            player.Alias = alias;

            await Save();

            return player;
        }
    }
}
