namespace ClashRoyaleClanWarsAPI.Infrastructure.Options;

public class JwtSettings
{
    public const string SectionName = "JwtSettings";
    public string SecretKey { get; init; } = null!;
    public int ExpiryMinutes { get; init; }
}
