using ClashRoyaleClanWarsAPI.Domain.Models;

namespace ClashRoyaleClanWarsAPI.Domain.Relationships;

public class ClanWarsModel
{
    private ClanWarsModel() { }
    public int ClanId { get; private set; } 
    public ClanModel? Clan { get; private set; }
    public int WarId { get; private set; }
    public WarModel? War { get; private set; }
    public int Prize { get; private set; }

    public static ClanWarsModel Create(int clanId, int warId, int prize)
    {
        return new ClanWarsModel()
        {
            ClanId = clanId,
            WarId = warId,
            Prize = prize
        };
    }
}
