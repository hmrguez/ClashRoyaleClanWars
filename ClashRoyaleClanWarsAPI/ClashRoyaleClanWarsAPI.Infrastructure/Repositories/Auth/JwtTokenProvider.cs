using ClashRoyaleClanWarsAPI.Application.Auth.Response;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Auth;
using ClashRoyaleClanWarsAPI.Domain.Models;
using ClashRoyaleClanWarsAPI.Infrastructure.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ClashRoyaleClanWarsAPI.Infrastructure.Repositories.Auth;

internal sealed class JwtTokenProvider : IJwtTokenProvider
{
    private readonly JwtSettings _settings;

    public JwtTokenProvider(IOptions<JwtSettings> settings)
    {
        _settings = settings.Value;
    }

    public LoginResponse CreateToken(UserModel user, string role)
    {
        var expiration = DateTime.UtcNow.AddMinutes(_settings.ExpiryMinutes);

        var token = CreateJwtToken(CreataClaims(user, role, expiration), CreateSigningCredentials(), expiration);

        var tokenHandler = new JwtSecurityTokenHandler();

        return new LoginResponse(tokenHandler.WriteToken(token), expiration);
    }

    private JwtSecurityToken CreateJwtToken(Claim[] claims, SigningCredentials credentials, DateTime expiration) =>
        new(
            claims: claims,
            expires: expiration,
            signingCredentials: credentials);

    private Claim[] CreataClaims(UserModel user, string role, DateTime expiration)
    {
        List<Claim> claims = new()
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Role, role),
            new Claim(ClaimTypes.Expiration, expiration.ToString())
        };

        return claims.ToArray();
    }


    private SigningCredentials CreateSigningCredentials() =>
        new(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_settings.SecretKey)
                ),
            SecurityAlgorithms.HmacSha256);
}
