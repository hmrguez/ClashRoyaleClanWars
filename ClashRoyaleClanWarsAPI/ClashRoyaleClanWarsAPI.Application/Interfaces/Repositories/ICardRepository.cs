using ClashRoyaleClanWarsAPI.Domain.Models.Card;

namespace ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;

public interface ICardRepository : IBaseRepository<CardModel, int>
{
    public Task<IEnumerable<CardModel>> GetCardsByNameAsync(string name);
}
