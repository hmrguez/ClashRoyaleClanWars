using ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;
using ClashRoyaleClanWarsAPI.Domain.Models;

namespace ClashRoyaleClanWarsAPI.Application.Interfaces.Auth;

public interface IUserRepository : IBaseRepository<UserModel, Guid>
{
    Task<UserModel> GetUserByNameAsync(string username);
    Task<UserModel> Add(string username, string password, RoleModel role);
    Task Delete(Guid id);
    Task UpdateRole(Guid id, string role);
}
