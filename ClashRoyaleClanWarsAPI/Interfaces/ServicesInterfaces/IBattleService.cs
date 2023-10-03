using ClashRoyaleClanWarsAPI.Models;

namespace ClashRoyaleClanWarsAPI.Interfaces.ServicesInterfaces
{
    public interface IBattleService
    {
        public Task<IEnumerable<BattleModel>> GetAllAsync();
        public Task<BattleModel> GetSingleByIdAsync(Guid id);
        public Task<BattleModel> GetSingleByIdAsync(Guid id, bool fullLoad = false);
        public Task<Guid> AddAsync(BattleModel battle, int winnerId);
        public Task Save();
    }
}
