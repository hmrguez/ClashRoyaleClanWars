namespace ClashRoyaleClanWarsAPI.Dtos.ClanDto
{
    public class UpdateClanDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Region { get; set; }
        public bool TypeOpen { get; set; }
        public int MinTrophies { get; set; }
    }
}
