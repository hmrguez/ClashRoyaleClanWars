namespace ClashRoyaleClanWarsAPI.Application.Auth.Response;

public class LoginResponse
{
    public string Token { get; set; }
    public DateTime Expiration { get; set; }

    public LoginResponse(string token, DateTime expiration)
    {
        Token = token;
        Expiration = expiration;
    }
}
