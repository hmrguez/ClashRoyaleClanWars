using ClashRoyaleClanWarsAPI.Data;
using ClashRoyaleClanWarsAPI.Exceptions;
using ClashRoyaleClanWarsAPI.Interfaces.ServicesInterfaces;
using ClashRoyaleClanWarsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClashRoyaleClanWarsAPI.Services
{
    public class PlayerService : BaseService<PlayerModel>, IPlayerService
    {
        private readonly ICardService _cardService;

        public PlayerService(DataContext context, ICardService cardService) : base(context)
        {
            _cardService = cardService;
        }

        public async override Task<PlayerModel> GetSingleByIdAsync(int id)
        {
            if (_context.Players == null) throw new ModelNotFoundException<PlayerModel>();

            var entity = _context.Players
                .Include(p=> p.Cards)
                .ThenInclude(c=> c.Card)
                .Where(p=> p.Id ==id).First();

            return entity ?? throw new IdNotFoundException<PlayerModel>(id);
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

            player.Cards.Add(collect);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CardModel>> GetAllCardsOfPlayerAsync(int id)
        {
            if(_context.Players == null) throw new ModelNotFoundException<PlayerModel>();

            
            PlayerModel player = await GetSingleByIdAsync(id);

            
            return player.Cards.Select(c=>c.Card);

        }

        public async Task<IEnumerable<PlayerModel>> GetPlayersByAliasAsync(string alias)
        {
            if (_context.Players == null) throw new ModelNotFoundException<PlayerModel>();

            return (await GetAllAsync()).Where(c=>c.Alias == alias);

        }
    }
}
