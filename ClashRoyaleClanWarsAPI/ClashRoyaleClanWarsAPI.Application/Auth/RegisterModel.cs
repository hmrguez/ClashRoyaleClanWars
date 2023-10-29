namespace ClashRoyaleClanWarsAPI.Application.Auth;

public class RegisterModel
{
    private RegisterModel() { }
    public string? Username { get; private set; }
    public string? Password { get; private set; }
    public string? ConfirmPassword { get; private set; }

    public static RegisterModel Create(string username, string password, string confirmPassword)
    {
        var registerModel = new RegisterModel()
        {
            Username = username,
            Password = password,
            ConfirmPassword = confirmPassword
        };

        return registerModel;
    }
}
