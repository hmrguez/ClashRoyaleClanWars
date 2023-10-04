using ClashRoyaleClanWarsAPI.Models;

namespace ClashRoyaleClanWarsAPI.Interfaces.ServicesInterfaces
{
    public interface IWarService : IBaseService<WarModel, int>
    {
        public Task<IEnumerable<WarModel>> GetWarsByDate(DateTime date);
    }
}
