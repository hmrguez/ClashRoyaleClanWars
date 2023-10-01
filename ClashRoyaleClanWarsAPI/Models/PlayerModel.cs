using ClashRoyaleClanWarsAPI.Interfaces.ServicesInterfaces;

namespace ClashRoyaleClanWarsAPI.Models
{
    public class PlayerModel : IEntity
    {
        public int Id { get; set; }
        public string Alias { get; set; }
        public int Elo { get; set; }
        public int Level { get; set; }
        public int Victories { get; set; }
        public int CardAmount { get; set; }
        public int MaxElo { get; set; }
        public CardModel FavoriteCard { get; set; }
        public List<CollectModel> Cards { get; set; }

    }
}
