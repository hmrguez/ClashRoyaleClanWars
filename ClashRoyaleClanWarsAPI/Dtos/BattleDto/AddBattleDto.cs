using ClashRoyaleClanWarsAPI.Models;

namespace ClashRoyaleClanWarsAPI.Dtos.BattleDto
{
    public class AddBattleDto
    {
        public int AmountTrophies { get; set; }
        public int WinnerId { get; set; }
        public int LoserId { get; set; }
        public int DurationInSeconds { get; set; }
    }
}
