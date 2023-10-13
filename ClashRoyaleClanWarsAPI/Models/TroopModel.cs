using ClashRoyaleClanWarsAPI.Enum;
using ClashRoyaleClanWarsAPI.Interfaces.ModelInterfaces;

namespace ClashRoyaleClanWarsAPI.Models
{
    public class TroopModel : CardModel, ITroopStructure
    {
        public int HitPoints { get ; set ; }
        public int Amount { get; set; }
        public float Range { get ; set ; }
        public SpeedCardEnum Speed { get; set; }
        public float HitSpeed { get ; set ; }
        public TransportCardEnum Transport { get; set; }
    }
}
