namespace ClashRoyaleClanWarsAPI.Domain.Exceptions.Auth;

public class InvalidPasswordException : Exception
{
    public InvalidPasswordException() : base("Invalid password")
    { }
}
