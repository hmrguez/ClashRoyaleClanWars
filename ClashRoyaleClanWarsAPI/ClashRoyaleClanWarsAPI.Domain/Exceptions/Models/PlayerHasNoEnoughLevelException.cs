namespace ClashRoyaleClanWarsAPI.Domain.Exceptions.Models;

public class PlayerHasNoEnoughLevelException : Exception
{
    public PlayerHasNoEnoughLevelException(int challengeLevel, int playerLevel)
        : base($"Challenge Min Lvl {challengeLevel} and player has {playerLevel}")
    {
    }
}
