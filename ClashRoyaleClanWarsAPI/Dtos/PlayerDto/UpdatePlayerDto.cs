namespace ClashRoyaleClanWarsAPI.Dtos.PlayerDto
{
    public class UpdatePlayerDto
    {
        public int Id { get; set; }
        public string Alias { get; set; }
        public int Elo { get; set; }
        public int Level { get; set; }
        public int Victories { get; set; }
        public int CardAmount { get; set; }
        public int MaxElo { get; set; }
        public int FavoriteCardId { get; set; }
    }
}
