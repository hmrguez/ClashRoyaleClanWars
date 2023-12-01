namespace ClashRoyaleClanWarsAPI.Application.Auth.Response;

public class UserResponse
{
    private UserResponse() { }

    public Guid? Id { get; init; }
    public string? Username { get; init; }
    public string? Role { get; init; }
    public int? PlayerId { get; init; }

    public static UserResponse Create(Guid id, string username, string role, int? playerId)
    {
        var user = new UserResponse()
        {
            Id = id,
            Username = username,
            Role = role,
            PlayerId = playerId
        };

        return user;
    }
}
