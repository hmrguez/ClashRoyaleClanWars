using ClashRoyaleClanWarsAPI.Domain.Models;

namespace ClashRoyaleClanWarsAPI.Application.Common.Mapping;

public class ClanWarDto
{
    public int ClanId { get; private set; } 
    public ClanModel? Clan { get; private set; }
    public int Prize { get; private set; }
}
