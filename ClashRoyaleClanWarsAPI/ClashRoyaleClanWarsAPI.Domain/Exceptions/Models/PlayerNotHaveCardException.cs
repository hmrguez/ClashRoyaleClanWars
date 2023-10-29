namespace ClashRoyaleClanWarsAPI.Domain.Exceptions.Models;

public class PlayerNotHaveCardException : Exception
{
    public PlayerNotHaveCardException() : base("Player does not have card") { }
}
