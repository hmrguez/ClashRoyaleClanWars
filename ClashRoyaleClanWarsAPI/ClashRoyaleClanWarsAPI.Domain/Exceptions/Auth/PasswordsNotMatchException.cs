namespace ClashRoyaleClanWarsAPI.Domain.Exceptions.Auth;

public class PasswordsNotMatchException : Exception
{
    public PasswordsNotMatchException() : base("Passwords do not match")
    {
    }
}
