namespace ClashRoyaleClanWarsAPI.API.Common.Mapping.Objects;

public class RegisterRequest
{
    public required string Username { get;  set; }
    public required string Password { get; set; }
    public required string ConfirmPassword { get; set; }
}
