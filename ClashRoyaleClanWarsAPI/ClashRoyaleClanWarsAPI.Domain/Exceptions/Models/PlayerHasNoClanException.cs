namespace ClashRoyaleClanWarsAPI.Domain.Exceptions.Models;

public class PlayerHasNoClanException : Exception
{
    public PlayerHasNoClanException(int id) : base($"PlayerId {id} does not have a clan")
    {
    }
}
