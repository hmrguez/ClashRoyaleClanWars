using ClashRoyaleClanWarsAPI.Domain.Models;

namespace ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;

public interface IWarRepository : IBaseRepository<WarModel, int>
{
    public Task<IEnumerable<WarModel>> GetWarsByDate(DateTime date);
    public Task AddClanToWar(int warId, int clanId, int prize);
}
