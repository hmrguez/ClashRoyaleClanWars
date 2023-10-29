using ClashRoyaleClanWarsAPI.Application.Auth.Response;
using ClashRoyaleClanWarsAPI.Application.Auth.User;

namespace ClashRoyaleClanWarsAPI.Application.Interfaces.Auth;

public interface IUserRepository
{
    Task<IEnumerable<UserModel>> GetAllAsync();
    Task<UserResponse> GetUserByNameAsync(string username);
    Task<UserResponse> GetUserByIdAsync(string id);
    Task Delete(string id);
}
