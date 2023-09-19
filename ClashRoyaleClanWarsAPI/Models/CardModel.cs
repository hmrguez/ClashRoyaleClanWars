namespace ClashRoyaleClanWarsAPI.Models
{
    public enum Denomination
    {
        Unknown,
        Spell,
        Structure,
        Troop
    }
    public enum Quality
    {
        Common,
        Rare,
        Epic,
        Legendary
    }

    public abstract class CardModel
    {
        public int Id { get; set; }
        public string Name { get;set; }
        public Denomination Type { get; set; }
        public string Description { get; set; }
        public int Elixir { get; set; }
        public Quality Quality { get; set; }
        public int AreaDamage { get; set; }
        public int InitialLevel { get; set; }
        public List<CollectModel> CardOwners { get; set; }
    }
}
