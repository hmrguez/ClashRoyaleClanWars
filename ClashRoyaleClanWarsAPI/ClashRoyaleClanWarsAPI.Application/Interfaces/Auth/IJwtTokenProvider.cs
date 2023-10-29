using ClashRoyaleClanWarsAPI.Application.Auth.Response;
using ClashRoyaleClanWarsAPI.Application.Auth.User;

namespace ClashRoyaleClanWarsAPI.Application.Interfaces.Auth;

public interface IJwtTokenProvider
{
    LoginResponse CreateToken(UserModel user, IList<string> roles);
}
