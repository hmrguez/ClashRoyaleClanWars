namespace ClashRoyaleClanWarsAPI.Models
{
    public class PlayerChallengesModel
    {
        public PlayerModel Player { get; set; }
        public ChallengeModel Challenge { get; set; }
        public int PrizeAmount { get; set; }
    }
}
