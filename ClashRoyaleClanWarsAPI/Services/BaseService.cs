using ClashRoyaleClanWarsAPI.Data;
using ClashRoyaleClanWarsAPI.Exceptions;
using ClashRoyaleClanWarsAPI.Interfaces.ServicesInterfaces;
using ClashRoyaleClanWarsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClashRoyaleClanWarsAPI.Services
{
    public class BaseService<T> : IBaseService<T> where T : class, IEntity
    {
        protected readonly DataContext _context;
        public BaseService(DataContext context)
        {
            _context = context;
        }
        public virtual async Task<T> GetSingleByIdAsync(int id)
        {
            if (_context.Set<T>() == null) throw new ModelNotFoundException<T>();

            var entity = await _context.Set<T>().FindAsync(id);

            return entity ?? throw new IdNotFoundException<T>(id);
        }
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            if (_context.Set<T>() == null) throw new ModelNotFoundException<T>();

            return await _context.Set<T>().ToListAsync();
        }
        public virtual async Task<int> Add(T model)
        {
            if (_context.Set<T>() == null) throw new ModelNotFoundException<T>();

            _context.Set<T>().Add(model);

            await _context.SaveChangesAsync();
            return model.Id;
        }
        public virtual async Task Delete(int id)
        {
            if (_context.Set<T>() == null) throw new ModelNotFoundException<T>();

            T entity;

            try
            {
                entity = await GetSingleByIdAsync(id);
            }
            catch (IdNotFoundException<CardModel>)
            {
                throw;
            }
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
        public virtual async Task Update(T model)
        {
            if (_context.Set<T>() == null) throw new ModelNotFoundException<T>();
            if (!await ExistsId(model.Id)) throw new IdNotFoundException<T>(model.Id);

            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public virtual async Task<bool> ExistsId(int id)
        {
            return await _context.Set<T>().AnyAsync(e => e.Id == id);
        }
    }
}
