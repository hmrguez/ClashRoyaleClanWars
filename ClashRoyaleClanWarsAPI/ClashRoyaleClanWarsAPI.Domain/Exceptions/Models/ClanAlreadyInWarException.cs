namespace ClashRoyaleClanWarsAPI.Domain.Exceptions.Models;

public class ClanAlreadyInWarException : Exception
{
    public ClanAlreadyInWarException(int clanId) : base($"Clan {clanId} already in war")
    {
    }
}
