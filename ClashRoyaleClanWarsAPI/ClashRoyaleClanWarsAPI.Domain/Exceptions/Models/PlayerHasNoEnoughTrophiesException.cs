namespace ClashRoyaleClanWarsAPI.Domain.Exceptions.Models;

public class PlayerHasNoEnoughTrophiesException : Exception
{
    public PlayerHasNoEnoughTrophiesException(int playerTrophies, int minClanTrophies) 
        : base($"Player has {playerTrophies} trophies. {minClanTrophies - playerTrophies} left trophies to enter the clan.")
    {
    }
}
