using ClashRoyaleClanWarsAPI.Domain.Common.Interfaces;
using ClashRoyaleClanWarsAPI.Domain.Models.Battle.ValueObjects;

namespace ClashRoyaleClanWarsAPI.Domain.Models.Battle;

public class BattleModel : IEntity<BattleId>
{
    private BattleModel() 
    {
        Id = CreateId();
    }
    public BattleId Id { get; private set; }
    public int AmountTrophies { get; private set; }
    public PlayerModel? Winner { get; private set; }
    public PlayerModel? Loser { get; private set; }
    public int DurationInSeconds { get; private set; }
    public DateTime Date { get; private set; }

    private static BattleId CreateId() => BattleId.CreateUnique();

    public static BattleModel Create(int amountTrophies, PlayerModel winner, PlayerModel loser, int durationInSeconds)
    {
        return new BattleModel
        {
            AmountTrophies = amountTrophies,
            Winner = winner,
            Loser = loser,
            DurationInSeconds = durationInSeconds
        };
    }

    public void AddDate()
    {
        Date = DateTime.Now;
    }
}
