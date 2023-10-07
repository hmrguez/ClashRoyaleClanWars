using ClashRoyaleClanWarsAPI.Interfaces.ServicesInterfaces;

namespace ClashRoyaleClanWarsAPI.Models
{
    public class BattleModel : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public int AmountTrophies { get; set; }
        public PlayerModel Winner {  get; set; }
        public int DurationInSeconds { get; set; }
        public DateTime Date { get; set; }
    }
}
