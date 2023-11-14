using ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;
using ClashRoyaleClanWarsAPI.Domain.Common.Interfaces;
using ClashRoyaleClanWarsAPI.Domain.Exceptions;
using ClashRoyaleClanWarsAPI.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace ClashRoyaleClanWarsAPI.Infrastructure.Repositories.Common;

public class BaseRepository<TModel, UId> : IBaseRepository<TModel, UId> where TModel : class, IEntity<UId>
{
    protected readonly ClashRoyaleDbContext _context;
    public BaseRepository(ClashRoyaleDbContext context)
    {
        _context = context;
    }
    public virtual async Task<TModel> GetSingleByIdAsync(UId id)
    {
        var entity = await _context.Set<TModel>().FindAsync(id) ?? throw new IdNotFoundException<UId>(id);

        return entity;
    }
    public virtual async Task<IEnumerable<TModel>> GetAllAsync()
    {
        return await _context.Set<TModel>().ToListAsync();
    }
    public virtual async Task<UId> Add(TModel model)
    {
        _context.Set<TModel>().Add(model);

        await Save();

        return model.Id;
    }
    public virtual async Task Delete(TModel model)
    {
        _context.Set<TModel>().Remove(model);
        await Save();
    }
    public virtual async Task Update(TModel model)
    {
        _context.Entry(model).State = EntityState.Modified;
        await Save();
    }
    public virtual async Task Save() => await _context.SaveChangesAsync();
    public virtual async Task<bool> ExistsId(UId id)
    {
        return await _context.Set<TModel>().AnyAsync(e => e.Id!.Equals(id));
    }
}
