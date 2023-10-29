using ClashRoyaleClanWarsAPI.Domain.Models;

namespace ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;

public interface IWarRepository : IBaseRepository<WarModel, int>
{
    public Task<IEnumerable<WarModel>> GetWarsByDate(DateTime date);
}
