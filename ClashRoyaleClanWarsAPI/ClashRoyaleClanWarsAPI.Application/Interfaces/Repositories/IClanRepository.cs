using ClashRoyaleClanWarsAPI.Domain.Enum;
using ClashRoyaleClanWarsAPI.Domain.Models;
using ClashRoyaleClanWarsAPI.Domain.Relationships;

namespace ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;

public interface IClanRepository : IBaseRepository<ClanModel, int>
{
    public Task<ClanModel> GetSingleByIdAsync(int id, bool fullLoad = false);
    public Task<IEnumerable<ClanModel>> GetAllByName(string name);
    public Task<IEnumerable<ClanModel>> GetAllAvailable(int trophies);
    public Task<IEnumerable<ClanPlayersModel>> GetPlayers(int clanId);
    public Task<int> Add(int playerId, ClanModel clan);
    public Task AddPlayer(int clanId, int playerId, RankClan rank = RankClan.Member);
    public Task RemovePlayer(int clanId, int playerId);
    public Task UpdatePlayerRank(int clanId, int playerId, RankClan rank);
}
