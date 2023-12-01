using ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;
using ClashRoyaleClanWarsAPI.Domain.Models;

namespace ClashRoyaleClanWarsAPI.Application.Interfaces.Auth;

public interface IRoleManager : IBaseRepository<RoleModel, Guid>
{
    Task<RoleModel> GetRoleByNameAsync(string name);
}
