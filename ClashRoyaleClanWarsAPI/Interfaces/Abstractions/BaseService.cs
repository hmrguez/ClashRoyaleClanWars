using ClashRoyaleClanWarsAPI.Interfaces.ServicesInterfaces;
using Microsoft.EntityFrameworkCore;

namespace ClashRoyaleClanWarsAPI.Interfaces.Abstractions;

public interface ICrudService<T> where T: class, IEntity
{
    protected static DbContext _context;

    public virtual async Task<T> GetSingleByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public virtual async Task<int> Add(T model)
    {
        _context.Set<T>().Add(model);
        await _context.SaveChangesAsync();
        return model.Id;
    }

    public virtual async Task Update(T model)
    {
        _context.Entry(model).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public virtual async Task Delete(int id)
    {
        var entity = await GetSingleByIdAsync(id);
        if (entity != null)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    public virtual async Task<bool> ExistsId(int id)
    {
        return await _context.Set<T>().AnyAsync(e => e.Id == id);
    }
}