using ClashRoyaleClanWarsAPI.Interfaces.ServicesInterfaces;

namespace ClashRoyaleClanWarsAPI.Models
{
    public class BattleModel
    {
        public Guid Id { get; set; }
        public int AmountTrophies { get; set; }
        public PlayerModel Winner {  get; set; }
        public int DurationInSeconds { get; set; }
    }
}
