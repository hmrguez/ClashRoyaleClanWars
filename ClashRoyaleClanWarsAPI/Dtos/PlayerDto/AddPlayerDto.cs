namespace ClashRoyaleClanWarsAPI.Dtos.PlayerDto
{
    public class AddPlayerDto
    {
        public string Alias { get; set; }
        public int Elo { get; set; }
        public int Level { get; set; }
        public int Victories { get; set; }
        public int MaxElo { get; set; }
    }
}
