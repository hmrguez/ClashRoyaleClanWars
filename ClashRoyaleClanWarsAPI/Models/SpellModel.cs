using ClashRoyaleClanWarsAPI.Interfaces.ModelInterfaces;

namespace ClashRoyaleClanWarsAPI.Models
{
    public class SpellModel : CardModel, ISpellStructure
    {
        public int Radius { get ; set ;}
        public int TowerDamage { get; set ;}
        public int Duration { get; set ;}
    }
}
