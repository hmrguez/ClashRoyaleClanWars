using ClashRoyaleClanWarsAPI.Interfaces.Abstractions;
using ClashRoyaleClanWarsAPI.Models;

namespace ClashRoyaleClanWarsAPI.Interfaces.ServicesInterfaces
{
    public interface ICardService<T> : ICrudService<T> where T : class, IEntity
    {
        public Task<IEnumerable<T>> GetCardsByNameAsync(string name);
        public Task AddAllCards();
    }
}
