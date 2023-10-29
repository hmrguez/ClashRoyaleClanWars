namespace ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;

public interface IBaseRepository<TModel, UId>
{
    public Task<TModel> GetSingleByIdAsync(UId id);
    public Task<IEnumerable<TModel>> GetAllAsync();
    public Task<UId> Add(TModel model);
    public Task Update(TModel model);
    public Task Delete(TModel model);
    public Task<bool> ExistsId(UId id);
    public Task Save();

}
