namespace ClashRoyaleClanWarsAPI.Interfaces.ServicesInterfaces
{
    public interface IService<T>
    {
        public Task<T> GetSingleByIdAsync(int id);
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<int> Add(T model);
        public Task Update(T model);
        public Task Delete(int id);
        public Task<bool> ExistsId(int id);

    }
}
