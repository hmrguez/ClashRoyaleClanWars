using ClashRoyaleClanWarsAPI.Data;
using ClashRoyaleClanWarsAPI.Exceptions;
using ClashRoyaleClanWarsAPI.Interfaces.ServicesInterfaces;
using ClashRoyaleClanWarsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClashRoyaleClanWarsAPI.Services
{
    public class BaseService<T, U> : IBaseService<T, U> where T : class, IEntity<U>
    {
        protected readonly DataContext _context;
        public BaseService(DataContext context)
        {
            _context = context;
        }
        public virtual async Task<T> GetSingleByIdAsync(U id)
        {
            if (_context.Set<T>() == null) throw new ModelNotFoundException<T>();

            var entity = await _context.Set<T>().FindAsync(id);

            return entity ?? throw new IdNotFoundException<T, U>(id);
        }
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            if (_context.Set<T>() == null) throw new ModelNotFoundException<T>();

            return await _context.Set<T>().ToListAsync();
        }
        public virtual async Task<U> Add(T model)
        {
            if (_context.Set<T>() == null) throw new ModelNotFoundException<T>();

            _context.Set<T>().Add(model);

            await Save();
            return model.Id;
        }
        public virtual async Task Delete(U id)
        {
            if (_context.Set<T>() == null) throw new ModelNotFoundException<T>();

            T entity = await GetSingleByIdAsync(id);

            _context.Set<T>().Remove(entity);
            await Save();
        }
        public virtual async Task Update(T model)
        {
            if (_context.Set<T>() == null) throw new ModelNotFoundException<T>();
            if (!(await ExistsId(model.Id))) throw new IdNotFoundException<T, U>(model.Id);

            _context.Entry(model).State = EntityState.Modified;
            await Save();
        }
        public virtual async Task Save() => await _context.SaveChangesAsync();
        public virtual async Task<bool> ExistsId(U id)
        {
            return await _context.Set<T>().AnyAsync(e => e.Id!.Equals(id));
        }
    }
}
