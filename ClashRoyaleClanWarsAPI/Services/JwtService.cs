using ClashRoyaleClanWarsAPI.Interfaces.ServicesInterfaces;
using ClashRoyaleClanWarsAPI.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ClashRoyaleClanWarsAPI.Services
{
    public class JwtService :ITokenCreationService
    {
        private const int EXPIRATION_HOURS = 1;
        private readonly IConfiguration _configuration;

        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public LoginResponse CreateToken(IdentityUser user, IList<string> roles)
        {
            var expiration = DateTime.UtcNow.AddHours(EXPIRATION_HOURS);

            var token = CreateJwtToken(CreataClaims(user, roles), CreateSigningCredentials(), expiration);

            var tokenHandler = new JwtSecurityTokenHandler();

            return new LoginResponse(tokenHandler.WriteToken(token), expiration);
        }

        private JwtSecurityToken CreateJwtToken(Claim[] claims, SigningCredentials credentials, DateTime expiration) =>
            new JwtSecurityToken(
                claims: claims,
                expires: expiration,
                signingCredentials: credentials);

        private Claim[] CreataClaims(IdentityUser user, IList<string> roles)
        {
            List<Claim> claims = new List<Claim>(roles.Select(r => new Claim(ClaimTypes.Role, r)))
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName!)
            };

            return claims.ToArray();
        }
            

        private SigningCredentials CreateSigningCredentials() =>
            new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]!)
                    ),
                SecurityAlgorithms.HmacSha256);
    }
        
}
