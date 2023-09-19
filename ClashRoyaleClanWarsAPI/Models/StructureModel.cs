using ClashRoyaleClanWarsAPI.Interfaces.ModelInterfaces;

namespace ClashRoyaleClanWarsAPI.Models
{
    public class StructureModel : CardModel, ISpellStructure, ITroopStructure
    {
        public int Radius { get ; set ; }
        public int HitPoints { get ; set ; }
        public float AttackSpeed { get; set ; } 
    }
}
