using ClashRoyaleClanWarsAPI.Interfaces.ModelInterfaces;

namespace ClashRoyaleClanWarsAPI.Models
{
    public class StructureModel : CardModel, ISpellStructure, ITroopStructure
    {
        public float Radius { get ; set ; }
        public int HitPoints { get ; set ; }
        public float HitSpeed { get; set ; }
        public int LifeTime { get; set; }
        public float Range { get ; set ; }
    }
}
