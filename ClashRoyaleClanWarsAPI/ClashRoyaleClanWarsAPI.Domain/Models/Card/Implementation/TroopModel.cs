using ClashRoyaleClanWarsAPI.Domain.Enum;

namespace ClashRoyaleClanWarsAPI.Domain.Models.Card.Implementation;

public sealed class TroopModel : CardModel
{
    public int HitPoints { get; set; }
    public int Amount { get; set; }
    public float Range { get; set; }
    public SpeedCardEnum Speed { get; set; }
    public float HitSpeed { get; set; }
    public TransportCardEnum Transport { get; set; }

    public TroopModel AddId(int id)
    {
        Id = id;
        return this;
    }
    
}
