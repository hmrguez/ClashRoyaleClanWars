namespace ClashRoyaleClanWarsAPI.Models
{
    public enum RankClan
    {
        Leader,
        CoLeader,
        Veteran,
        Member
    }
    public class PlayerClansModel
    {
        public ClanModel? Clan { get; set; }
        public PlayerModel? Player { get; set; }
        public RankClan Rank { get; set; }
    }
}
