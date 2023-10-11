using ClashRoyaleClanWarsAPI.Enum;
using ClashRoyaleClanWarsAPI.Interfaces.ServicesInterfaces;

namespace ClashRoyaleClanWarsAPI.Models
{
    public abstract class CardModel : IEntity<int>
    {
        public int Id { get; set; }
        public string? Name { get;set; }
        public TypeCardEnum Type { get; set; }
        public string? Description { get; set; }
        public int Elixir { get; set; }
        public QualityCardEnum Quality { get; set; }
        public int Damage { get; set; }
        public bool AreaDamage { get;set; }
        public TargetCardEnum Target { get; set; }
        public int InitialLevel { get; set; }
        public string? ImageUrl { get; set; }
    }
}
