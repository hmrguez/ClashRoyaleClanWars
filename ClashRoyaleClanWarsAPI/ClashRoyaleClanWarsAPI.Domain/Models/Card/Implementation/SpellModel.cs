namespace ClashRoyaleClanWarsAPI.Domain.Models.Card.Implementation;

public sealed class SpellModel : CardModel
{
    public float Radius { get; set; }
    public int TowerDamage { get; set; }
    public int LifeTime { get; set; }

    public SpellModel AddId(int id)
    {
        Id = id;
        return this;
    }

}
