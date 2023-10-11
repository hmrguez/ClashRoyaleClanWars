using ClashRoyaleClanWarsAPI.Models;

namespace ClashRoyaleClanWarsAPI.Dtos.CollectDto
{
    public class GetCollectDto
    {
        public CardModel? Card { get; set; }
        public int Level { get; set; }
        public DateTime Date { get; set; }
    }
}
