using ClashRoyaleClanWarsAPI.Dtos;
using ClashRoyaleClanWarsAPI.Utils;

namespace ClashRoyaleClanWarsAPI.Interfaces.ServicesInterfaces
{
    public interface IUserService
    {
        Task<UserManagerResponse> RegisterUserAsync(RegisterUserModel user);
        Task<User> GetUserAsync(string username);
        Task<LoginResponse> LoginUserAsync(LoginUserModel user)
    }
}
