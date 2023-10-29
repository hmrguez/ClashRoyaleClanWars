namespace ClashRoyaleClanWarsAPI.Domain.Exceptions.Models;

public class ChallengeClosedException : Exception
{
    public ChallengeClosedException() : base("Challenge is not open") { }
}
