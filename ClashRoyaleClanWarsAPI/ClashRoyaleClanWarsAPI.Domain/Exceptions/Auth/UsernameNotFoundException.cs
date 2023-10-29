namespace ClashRoyaleClanWarsAPI.Domain.Exceptions.Auth;

public class UsernameNotFoundException : Exception
{
    public UsernameNotFoundException() : base("Username does not exists")
    { }
}
