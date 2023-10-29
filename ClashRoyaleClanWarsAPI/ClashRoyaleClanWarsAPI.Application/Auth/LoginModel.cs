namespace ClashRoyaleClanWarsAPI.Application.Auth;

public class LoginModel
{
    private LoginModel() { }
    public string? Username { get; set; }
    public string? Password { get; set; }

    public static LoginModel Create(string username, string password)
    {
        var loginModel = new LoginModel()
        {
            Username = username,
            Password = password
        };

        return loginModel;
    }
}
