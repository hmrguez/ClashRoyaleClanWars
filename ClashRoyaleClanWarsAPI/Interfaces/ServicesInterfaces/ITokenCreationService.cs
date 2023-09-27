using ClashRoyaleClanWarsAPI.Utils;
using Microsoft.AspNetCore.Identity;

namespace ClashRoyaleClanWarsAPI.Interfaces.ServicesInterfaces
{
    public interface ITokenCreationService
    {
        LoginResponse CreateToken(IdentityUser user);
    }
}
