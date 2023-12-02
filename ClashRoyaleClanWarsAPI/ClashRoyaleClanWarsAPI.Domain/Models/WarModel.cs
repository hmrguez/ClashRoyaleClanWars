using ClashRoyaleClanWarsAPI.Domain.Common.Interfaces;
using ClashRoyaleClanWarsAPI.Domain.Relationships;

namespace ClashRoyaleClanWarsAPI.Domain.Models;

public class WarModel : IEntity<int>
{
    private WarModel() { }
    public int Id { get; private set; }
    public DateTime StartDate { get; private set; }
    public List<ClanWarsModel> ClansInWar { get; private set; }

    public static WarModel Create(DateTime start)
    {
        return new WarModel()
        {
            StartDate = start,
        };
    }
}
