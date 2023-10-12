using ClashRoyaleClanWarsAPI.Dtos;
using ClashRoyaleClanWarsAPI.Utils;
using Microsoft.AspNetCore.Identity;

namespace ClashRoyaleClanWarsAPI.Interfaces.ServicesInterfaces
{
    public interface IUserService
    {
        Task<IEnumerable<IdentityUser>> GetAllAsync();
        Task<User> GetUserByNameAsync(string username);
        Task<User> GetUserByIdAsync(string id);
        Task Delete(string id);
    }
}
