using ClashRoyaleClanWarsAPI.Models;

namespace ClashRoyaleClanWarsAPI.Interfaces.ServicesInterfaces
{
    public interface IWarService : IBaseService<WarModel>
    {
        public Task<IEnumerable<WarModel>> GetWarsByDate(DateTime date);
    }
}
