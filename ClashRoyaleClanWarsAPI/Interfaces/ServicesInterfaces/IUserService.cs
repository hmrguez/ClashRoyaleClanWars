using ClashRoyaleClanWarsAPI.Dtos;
using ClashRoyaleClanWarsAPI.Utils;

namespace ClashRoyaleClanWarsAPI.Interfaces.ServicesInterfaces
{
    public interface IUserService
    {
        Task<RequestResponse<User>> RegisterUserAsync(RegisterModel user);
        Task<User> GetUserAsync(string username);
        Task<LoginResponse> LoginUserAsync(LoginUserModel user);
        Task<RequestResponse<User>> RegisterAdminAsync(RegisterModel user);
    }
}
