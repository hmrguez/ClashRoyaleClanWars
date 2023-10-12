using ClashRoyaleClanWarsAPI.Data;
using ClashRoyaleClanWarsAPI.Exceptions;
using ClashRoyaleClanWarsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClashRoyaleClanWarsAPI.Interfaces.ServicesInterfaces
{
    public interface IBaseService<T, U>
    {
        public Task<T> GetSingleByIdAsync(U id);
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<U> Add(T model);
        public Task Update(T model);
        public Task Delete(U id);
        public Task<bool> ExistsId(U id);
        public Task Save();

    }
}
