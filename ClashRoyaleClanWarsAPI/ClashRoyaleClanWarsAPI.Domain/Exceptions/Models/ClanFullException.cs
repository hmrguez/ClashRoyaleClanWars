namespace ClashRoyaleClanWarsAPI.Domain.Exceptions.Models;

public class ClanFullException : Exception
{
    public ClanFullException(int clanId) : base($"Clan {clanId} is already full")
    {
    }
}
