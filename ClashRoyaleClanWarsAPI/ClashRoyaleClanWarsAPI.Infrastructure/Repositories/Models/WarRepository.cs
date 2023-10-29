using ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;
using ClashRoyaleClanWarsAPI.Domain.Models;
using ClashRoyaleClanWarsAPI.Infrastructure.Persistance;
using ClashRoyaleClanWarsAPI.Infrastructure.Repositories.Common;

namespace ClashRoyaleClanWarsAPI.Infrastructure.Repositories.Models;

internal class WarRepository : BaseRepository<WarModel, int>, IWarRepository
{
    public WarRepository(ClashRoyaleDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<WarModel>> GetWarsByDate(DateTime date)
    {
        return (await GetAllAsync()).Where(w => w.StartDate > date);
    }
}
