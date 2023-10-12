using ClashRoyaleClanWarsAPI.Enum;
using ClashRoyaleClanWarsAPI.Models;

namespace ClashRoyaleClanWarsAPI.Dtos.CardsDto
{
    public class AddTroopDto
    {
        public string? Name { get; set; }
        public TypeCardEnum Type { get; set; }
        public string? Description { get; set; }
        public int Elixir { get; set; }
        public QualityCardEnum Quality { get; set; }
        public int Damage { get; set; }
        public bool AreaDamage { get; set; }
        public TargetCardEnum Target { get; set; }
        public int InitialLevel { get; set; }
        public string? ImageUrl { get; set; }
        public int HitPoints { get; set; }
        public int Amount { get; set; }
        public float Range { get; set; }
        public SpeedCardEnum Speed { get; set; }
        public float HitSpeed { get; set; }
        public TransportCardEnum Transport { get; set; }
    }
}
