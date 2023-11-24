namespace ClashRoyaleClanWarsAPI.Domain.Exceptions.Auth;

public class InvalidPasswordException : Exception
{
    public InvalidPasswordException(string message) : base(message)
    { }
}
