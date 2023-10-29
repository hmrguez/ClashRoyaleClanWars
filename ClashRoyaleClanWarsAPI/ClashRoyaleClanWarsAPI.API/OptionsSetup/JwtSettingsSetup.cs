using ClashRoyaleClanWarsAPI.Infrastructure.Options;
using Microsoft.Extensions.Options;

namespace ClashRoyaleClanWarsAPI.API.OptionsSetup;

public class JwtSettingsSetup : IConfigureOptions<JwtSettings>
{
    private readonly IConfiguration _configuration;

    public JwtSettingsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(JwtSettings options)
    {
        _configuration.GetSection(JwtSettings.SectionName).Bind(options);
    }
}
