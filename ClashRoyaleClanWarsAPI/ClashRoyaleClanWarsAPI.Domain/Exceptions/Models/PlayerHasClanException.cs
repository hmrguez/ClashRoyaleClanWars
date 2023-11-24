namespace ClashRoyaleClanWarsAPI.Domain.Exceptions.Models;

public class PlayerHasClanException : Exception
{
    public PlayerHasClanException() : base("Player already belongs to a clan") { }
}
