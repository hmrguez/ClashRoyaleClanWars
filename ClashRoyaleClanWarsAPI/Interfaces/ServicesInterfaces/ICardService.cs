using ClashRoyaleClanWarsAPI.Models;

namespace ClashRoyaleClanWarsAPI.Interfaces.ServicesInterfaces
{
    public interface ICardService<T> : IService<T>
    {
        public Task<IEnumerable<T>> GetCardsByNameAsync(string name);
        public Task AddAllCards();
    }
}
