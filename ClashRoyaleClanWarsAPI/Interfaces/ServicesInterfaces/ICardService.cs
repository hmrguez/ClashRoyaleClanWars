using ClashRoyaleClanWarsAPI.Models;

namespace ClashRoyaleClanWarsAPI.Interfaces.ServicesInterfaces
{
    public interface ICardService : IBaseService<CardModel>
    {
        public Task<IEnumerable<CardModel>> GetCardsByNameAsync(string name);
        public Task AddAllCards();
    }
}
