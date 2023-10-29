using ClashRoyaleClanWarsAPI.Domain.Models;

namespace ClashRoyaleClanWarsAPI.Domain.Relationships;

public class ClanWarsModel
{
    private ClanWarsModel() { }
    public ClanModel? Clan { get; private set; }
    public WarModel? War { get; private set; }
    public int Prize { get; private set; }

    public static ClanWarsModel Create(ClanModel clan, WarModel war, int prize)
    {
        return new ClanWarsModel()
        {
            Clan = clan,
            War = war,
            Prize = prize
        };
    }
}
