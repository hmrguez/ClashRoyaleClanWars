using ClashRoyaleClanWarsAPI.Models;

namespace ClashRoyaleClanWarsAPI.Interfaces.ServicesInterfaces
{
    public interface ICardService : IBaseService<CardModel, int>
    {
        public Task<IEnumerable<CardModel>> GetCardsByNameAsync(string name);
        public Task AddAllCards();
    }
}
