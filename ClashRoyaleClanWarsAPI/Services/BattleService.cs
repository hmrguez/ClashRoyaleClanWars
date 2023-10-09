using AutoMapper;
using AutoMapper.QueryableExtensions;
using ClashRoyaleClanWarsAPI.Data;
using ClashRoyaleClanWarsAPI.Exceptions;
using ClashRoyaleClanWarsAPI.Interfaces.ServicesInterfaces;
using ClashRoyaleClanWarsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClashRoyaleClanWarsAPI.Services
{
    public class BattleService : BaseService<BattleModel,Guid>, IBattleService
    {
        private readonly IPlayerService _playerService;
        private readonly IMapper _mapper;

        public BattleService(DataContext context, IPlayerService playerService, IMapper mapper) : base(context)
        {
            _playerService = playerService;
            _mapper = mapper;
        }
        public async Task<Guid> Add(BattleModel battle, int winnerId, int loserId)
        {
            if (_context.Battles == null) throw new ModelNotFoundException<BattleModel>();

            var winner = await _playerService.GetSingleByIdAsync(winnerId);
            var loser = await _playerService.GetSingleByIdAsync(loserId);

            battle.Winner = winner;
            battle.Loser = loser;
            _context.Battles.Add(battle);

            await Save();

            return battle.Id;
        }

        public override async Task<IEnumerable<BattleModel>> GetAllAsync()
        {
            if (_context.Battles == null) throw new ModelNotFoundException<BattleModel>();

            return await _context.Battles
                            .Include(b=> b.Winner)
                            .ToListAsync();
        }

        public async Task<BattleModel> GetSingleByIdAsync(Guid id, bool fullLoad = false)
        {
            if (_context.Battles == null) throw new ModelNotFoundException<BattleModel>();

            BattleModel? battle = fullLoad ? _context.Battles
                                                .Include(c => c.Winner)
                                                .Where(c => c.Id == id)
                                                .First()
                                            :
                                             await GetSingleByIdAsync(id);

            return battle ?? throw new IdNotFoundException<BattleModel, Guid>(id);
        }

    }
}
