using ClashRoyaleClanWarsAPI.Application.Auth.Response;
using ClashRoyaleClanWarsAPI.Domain.Models;

namespace ClashRoyaleClanWarsAPI.Application.Interfaces.Auth;

public interface IJwtTokenProvider
{
    LoginResponse CreateToken(UserModel user, string role);
}
