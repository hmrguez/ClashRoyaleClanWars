using ClashRoyaleClanWarsAPI.Domain.Models.Battle;
using ClashRoyaleClanWarsAPI.Domain.Models.Battle.ValueObjects;

namespace ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;

public interface IBattleRepository : IBaseRepository<BattleModel, BattleId>
{
    public Task<BattleModel> GetSingleByIdAsync(Guid id, bool fullLoad = false);
    public Task<Guid> Add(BattleModel battle, int winnerId, int loserId);
}
