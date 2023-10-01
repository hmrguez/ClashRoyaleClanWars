using ClashRoyaleClanWarsAPI.Models;

namespace ClashRoyaleClanWarsAPI.Interfaces.ServicesInterfaces
{
    public interface IClanService : IBaseService<ClanModel>
    {
        public Task<IEnumerable<ClanModel>> GetAllByName(string name);
        public Task<IEnumerable<ClanModel>> GetAllByTrophies(int thropies);
        public Task<IEnumerable<ClanModel>> GetAllAvailableClans(int trophies);
    }
}
