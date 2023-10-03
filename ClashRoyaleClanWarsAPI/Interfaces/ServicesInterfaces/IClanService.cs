using ClashRoyaleClanWarsAPI.Models;

namespace ClashRoyaleClanWarsAPI.Interfaces.ServicesInterfaces
{
    public interface IClanService : IBaseService<ClanModel>
    {
        public Task<ClanModel> GetSingleByIdAsync(int id, bool fullLoad = false);
        public Task<IEnumerable<ClanModel>> GetAllByName(string name);
        public Task<IEnumerable<ClanModel>> GetAllByTrophies(int thropies);
        public Task<IEnumerable<ClanModel>> GetAllAvailableClans(int trophies);
        public Task<IEnumerable<PlayerClansModel>> GetPlayers(int clanId);
        public Task<int> Add(int playerId, ClanModel clan);
        public Task AddPlayer(int clanId, int playerId, RankClan rank= RankClan.Member);
        public Task RemovePlayer(int clanId, int playerId);
        public Task UpdatePlayerRank(int clanId, int playerId, RankClan rank);
    }
}
