using ClashRoyaleClanWarsAPI.Domain.Common.Interfaces;

namespace ClashRoyaleClanWarsAPI.Domain.Models;

public class ChallengeModel : IEntity<int>
{
    private ChallengeModel() { }
    public int Id { get; private set; }
    public string? Name { get; private set; }
    public string? Description { get; private set; }
    public int Cost { get; private set; }
    public int AmountReward { get; private set; }
    public DateTime StartDate { get; private set; }
    public int DurationInHours { get; private set; }
    public bool IsOpen { get; private set; }
    public int MinLevel { get; private set; }
    public int LossLimit { get; private set; }

    public static ChallengeModel Create(string name,
                                        string description,
                                        int cost,
                                        int amountReward,
                                        DateTime start,
                                        int durationInHours,
                                        bool isOpen,
                                        int minLevel,
                                        int lossLimit)
    {
        return new ChallengeModel()
        {
            Name = name,
            Description = description,
            Cost = cost,
            AmountReward = amountReward,
            StartDate = start,
            DurationInHours = durationInHours,
            IsOpen = isOpen,
            MinLevel = minLevel,
            LossLimit = lossLimit
        };
    }
}
