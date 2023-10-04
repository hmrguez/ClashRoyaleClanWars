using ClashRoyaleClanWarsAPI.Interfaces.ServicesInterfaces;

namespace ClashRoyaleClanWarsAPI.Models
{
    public enum DenominationEnum
    {
        Unknown,
        Spell,
        Structure,
        Troop
    }
    public enum QualityEnum
    {
        Common,
        Rare,
        Epic,
        Legendary,
        Champion
    }
    public enum TargetEnum
    {
        Ground,
        Air,
        Buildings,
        Ground_Air,
        Nothing
    }
    public enum SpeedEnum
    {
        Very_Slow,
        Slow,
        Medium,
        Fast,
        Very_Fast
    }
    public enum TransportEnum
    {
        Ground, 
        Air
    }

    public abstract class CardModel : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get;set; }
        public DenominationEnum Type { get; set; }
        public string Description { get; set; }
        public int Elixir { get; set; }
        public QualityEnum Quality { get; set; }
        public int Damage { get; set; }
        public bool AreaDamage { get;set; }
        public TargetEnum Target { get; set; }
        public int InitialLevel { get; set; }
        public string ImageUrl { get; set; }
    }
}
