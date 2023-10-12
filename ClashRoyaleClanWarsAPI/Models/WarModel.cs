using ClashRoyaleClanWarsAPI.Interfaces.ServicesInterfaces;

namespace ClashRoyaleClanWarsAPI.Models
{
    public class WarModel : IEntity<int>
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
    }
}
