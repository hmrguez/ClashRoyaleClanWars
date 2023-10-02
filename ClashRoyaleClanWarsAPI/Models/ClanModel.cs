using ClashRoyaleClanWarsAPI.Interfaces.ServicesInterfaces;

namespace ClashRoyaleClanWarsAPI.Models
{
    
    public class ClanModel : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Region { get; set; }
        public bool TypeOpen { get; set; }
        public int AmountMembers { get; set; }
        public int TrophiesInWar { get; set; }
        public int MinTrophies { get; set; }
        public List<PlayerClansModel> Players { get; set; }
    }
}
