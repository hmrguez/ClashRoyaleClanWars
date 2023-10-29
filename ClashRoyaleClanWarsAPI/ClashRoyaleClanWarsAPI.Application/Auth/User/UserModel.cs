namespace ClashRoyaleClanWarsAPI.Application.Auth.User;

public class UserModel
{
    private UserModel() { }
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? PasswordHash { get; set; }

    public static UserModel Create(string id, string name, string passwordHash)
    {
        var user = new UserModel()
        {
            Id = id,
            Name = name,
            PasswordHash = passwordHash
        };
        return user;
    }
}
