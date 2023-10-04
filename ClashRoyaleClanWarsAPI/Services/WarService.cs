using ClashRoyaleClanWarsAPI.Data;
using ClashRoyaleClanWarsAPI.Interfaces.ServicesInterfaces;
using ClashRoyaleClanWarsAPI.Models;

namespace ClashRoyaleClanWarsAPI.Services
{
    public class WarService : BaseService<WarModel, int>, IWarService
    {
        public WarService(DataContext context) : base(context)
        {
        }

        public async Task<IEnumerable<WarModel>> GetWarsByDate(DateTime date)
        {
            return (await GetAllAsync()).Where(w => w.StartDate > date);
        }
    }
}
