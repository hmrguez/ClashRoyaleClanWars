namespace ClashRoyaleClanWarsAPI.Models
{
    public class DonationModel
    {
        public PlayerModel Player { get; set; }
        public ClanModel Clan { get; set; }
        public CardModel Card { get; set; }
        public int Amount { get; set; }
    }
}
