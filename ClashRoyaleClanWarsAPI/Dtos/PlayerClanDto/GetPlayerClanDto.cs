using ClashRoyaleClanWarsAPI.Models;

namespace ClashRoyaleClanWarsAPI.Dtos.PlayerClanDto
{
    public class GetPlayerClanDto
    {
        public PlayerModel? Player { get; set; }
        public RankClan Rank { get; set; }
    }
}
