namespace ClashRoyaleClanWarsAPI.Models
{
    public class CollectModel
    {
        public PlayerModel? Player { get; set; }
        public CardModel? Card { get; set; }
        public int Level { get; set; }
        public DateTime Date { get; set; } 
    }
}
