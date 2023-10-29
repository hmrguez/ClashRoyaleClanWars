namespace ClashRoyaleClanWarsAPI.Domain.Models.Card.Implementation;

public sealed class StructureModel : CardModel
{
    public float Radius { get; set; }
    public int HitPoints { get; set; }
    public float HitSpeed { get; set; }
    public int LifeTime { get; set; }
    public float Range { get; set; }

    public StructureModel AddId(int id)
    {
        Id = id;
        return this;
    }
    
}
