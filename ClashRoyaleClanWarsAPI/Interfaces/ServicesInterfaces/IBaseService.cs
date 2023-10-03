using ClashRoyaleClanWarsAPI.Data;
using ClashRoyaleClanWarsAPI.Exceptions;
using ClashRoyaleClanWarsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClashRoyaleClanWarsAPI.Interfaces.ServicesInterfaces
{
    public interface IBaseService<T>
    {
        public Task<T> GetSingleByIdAsync(int id);
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<int> Add(T model);
        public Task Update(T model);
        public Task Delete(int id);
        public Task Save();

    }
}
