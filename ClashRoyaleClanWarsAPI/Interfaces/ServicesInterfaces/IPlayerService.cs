using ClashRoyaleClanWarsAPI.Models;

namespace ClashRoyaleClanWarsAPI.Interfaces.ServicesInterfaces
{
    public interface IPlayerService : IBaseService<PlayerModel, int>
    {
        public Task<PlayerModel> GetSingleByIdAsync(int id, bool fullLoad=false);
        public Task<IEnumerable<PlayerModel>> GetPlayersByAliasAsync(string alias);
        public Task<IEnumerable<CardModel>> GetAllCardsOfPlayerAsync(int id);
        public Task AddCard(int playerId, int cardId);
        public Task<PlayerModel> UpdateAlias(int playerId, string alias);
    }
}
