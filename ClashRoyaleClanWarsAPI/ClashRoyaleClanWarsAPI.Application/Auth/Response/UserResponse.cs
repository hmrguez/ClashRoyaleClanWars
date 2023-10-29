namespace ClashRoyaleClanWarsAPI.Application.Auth.Response;

public class UserResponse
{
    private UserResponse() { }

    public string? Id { get; set; }
    public string? Username { get; set; }
    public string? Role { get; set; }

    public static UserResponse Create(string id, string username, string role)
    {
        var user = new UserResponse()
        {
            Id = id,
            Username = username,
            Role = role
        };

        return user;
    }
}
