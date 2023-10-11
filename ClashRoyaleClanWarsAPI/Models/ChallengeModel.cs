namespace ClashRoyaleClanWarsAPI.Models
{
    public class ChallengeModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Cost { get; set; }
        public int AmountReward { get; set; }
        public DateTime StartDate { get; set; }
        public int DurationInHours { get; set; }
        public int MinLevel { get; set; }
        public int LossLimit { get; set; }
    }
}
