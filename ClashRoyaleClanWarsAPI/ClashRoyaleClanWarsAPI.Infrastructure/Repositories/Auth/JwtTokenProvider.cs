using ClashRoyaleClanWarsAPI.Application.Auth.Response;
using ClashRoyaleClanWarsAPI.Application.Auth.User;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Auth;
using ClashRoyaleClanWarsAPI.Infrastructure.Options;
using Microsoft.Extensions.Configuration;
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

    public LoginResponse CreateToken(UserModel user, IList<string> roles)
    {
        var expiration = DateTime.UtcNow.AddMinutes(_settings.ExpiryMinutes);

        var token = CreateJwtToken(CreataClaims(user, roles), CreateSigningCredentials(), expiration);

        var tokenHandler = new JwtSecurityTokenHandler();

        return new LoginResponse(tokenHandler.WriteToken(token), expiration);
    }

    private JwtSecurityToken CreateJwtToken(Claim[] claims, SigningCredentials credentials, DateTime expiration) =>
        new(
            claims: claims,
            expires: expiration,
            signingCredentials: credentials);

    private Claim[] CreataClaims(UserModel user, IList<string> roles)
    {
        List<Claim> claims = new(roles.Select(r => new Claim(ClaimTypes.Role, r)))
        {
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
            new Claim(ClaimTypes.NameIdentifier, user.Id!),
            new Claim(ClaimTypes.Name, user.Name!)
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
