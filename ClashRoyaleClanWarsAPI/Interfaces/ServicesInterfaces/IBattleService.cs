using ClashRoyaleClanWarsAPI.Models;

namespace ClashRoyaleClanWarsAPI.Interfaces.ServicesInterfaces
{
    public interface IBattleService : IBaseService<BattleModel, Guid>
    {
        public Task<BattleModel> GetSingleByIdAsync(Guid id, bool fullLoad = false);
        public Task<Guid> Add(BattleModel battle, int winnerId, int loserId);
    }
}
