using ClashRoyaleClanWarsAPI.Domain.Models;
using ClashRoyaleClanWarsAPI.Domain.Models.Card;

namespace ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;

public interface IPlayerRepository : IBaseRepository<PlayerModel, int>
{
    public Task<PlayerModel> GetSingleByIdAsync(int id, bool fullLoad = false);
    public Task<IEnumerable<PlayerModel>> GetPlayersByAliasAsync(string alias);
    public Task<IEnumerable<CardModel>> GetAllCardsOfPlayerAsync(int playerId);
    public Task AddCard(int playerId, int cardId);
    public Task UpdateAlias(int playerId, string alias);
    public Task AddPlayerChallenge(int playerId, int challengeId, int reward);
    public Task AddPlayerChallengeResult(int playerId, int challengeId, int reward);
    public Task AddDonation(int playerId, int clanId, int cardId, int amount);

}
