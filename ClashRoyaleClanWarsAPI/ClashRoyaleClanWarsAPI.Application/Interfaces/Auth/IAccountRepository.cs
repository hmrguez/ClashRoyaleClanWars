using ClashRoyaleClanWarsAPI.Application.Auth;
using ClashRoyaleClanWarsAPI.Application.Auth.Response;
using ClashRoyaleClanWarsAPI.Application.Auth.Utils;

namespace ClashRoyaleClanWarsAPI.Application.Interfaces.Auth;

public interface IAccountRepository
{
    Task<UserResponse> RegisterUserAsync(RegisterModel registerModel, RoleEnum role);
    Task<LoginResponse> LoginUserAsync(LoginModel loginModel);
}
