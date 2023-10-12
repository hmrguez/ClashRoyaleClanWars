using ClashRoyaleClanWarsAPI.Dtos;
using ClashRoyaleClanWarsAPI.Utils;

namespace ClashRoyaleClanWarsAPI.Interfaces.ServicesInterfaces
{
    public interface IAccountService
    {
        Task<RequestResponse<User>> RegisterUserAsync(RegisterModel user);
        Task<LoginResponse> LoginUserAsync(LoginUserModel user);
        Task<RequestResponse<User>> RegisterAdminAsync(RegisterModel user);
    }
}
