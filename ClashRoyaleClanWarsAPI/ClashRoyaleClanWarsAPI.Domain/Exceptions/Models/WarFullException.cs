namespace ClashRoyaleClanWarsAPI.Domain.Exceptions.Models;

public class WarFullException : Exception
{
    public WarFullException(int warId) : base($"War {warId} is already full")
    {
    }
}
