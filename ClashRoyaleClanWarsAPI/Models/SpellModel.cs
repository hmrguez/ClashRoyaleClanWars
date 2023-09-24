using ClashRoyaleClanWarsAPI.Interfaces.ModelInterfaces;

namespace ClashRoyaleClanWarsAPI.Models
{
    public class SpellModel : CardModel, ISpellStructure
    {
        public float Radius { get ; set ;}
        public int TowerDamage { get; set ;}
        public int LifeTime { get; set ;}
    }
}
