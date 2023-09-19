using ClashRoyaleClanWarsAPI.Interfaces.ModelInterfaces;

namespace ClashRoyaleClanWarsAPI.Models
{
    public class TroopModel : CardModel, ITroopStructure
    {
        public int HitPoints { get ; set ; }
        public int Amount { get; set; }
    }
}
