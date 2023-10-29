using ClashRoyaleClanWarsAPI.Domain.Common.Interfaces;
using ClashRoyaleClanWarsAPI.Domain.Enum;
using ClashRoyaleClanWarsAPI.Domain.Relationships;

namespace ClashRoyaleClanWarsAPI.Domain.Models;

public class ClanModel : IEntity<int>
{
    public int Id { get; private set; }
    public string? Name { get; private set; }
    public string? Description { get; private set; }
    public string? Region { get; private set; }
    public bool TypeOpen { get; private set; }
    public int AmountMembers { get; private set; }
    public int TrophiesInWar { get; private set; }
    public int MinTrophies { get; private set; }
    public List<ClanPlayersModel>? Players { get; private set; }

    public void AddPlayer(PlayerModel player, RankClan rank = RankClan.Member)
    {
        Players ??= new List<ClanPlayersModel>();

        var playerClan = ClanPlayersModel.Create(player, this, rank);

        Players!.Add(playerClan);
    }

    public void AddAmountMember()
    {
        AmountMembers += 1;
    }
    public void RemoveAmountMember()
    {
        AmountMembers += 1;
    }
}
