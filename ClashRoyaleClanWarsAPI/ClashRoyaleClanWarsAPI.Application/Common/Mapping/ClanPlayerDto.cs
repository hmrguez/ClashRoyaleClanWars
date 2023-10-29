using ClashRoyaleClanWarsAPI.Domain.Enum;
using ClashRoyaleClanWarsAPI.Domain.Models;

namespace ClashRoyaleClanWarsAPI.Application.Common.Mapping;

public class ClanPlayerDto
{
    public PlayerModel? Player { get; set; }
    public RankClan Rank { get; set; }
}
