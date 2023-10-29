namespace ClashRoyaleClanWarsAPI.Domain.Exceptions.Auth;

public class UserCreationException : Exception
{
    public UserCreationException() : base("Something has occured")
    { }
}
