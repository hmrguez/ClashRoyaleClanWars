using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;
using ClashRoyaleClanWarsAPI.Domain.Enum;

namespace ClashRoyaleClanWarsAPI.Application.Models.Clan.Commands.UpdatePlayerRank;

public record UpdatePlayerRankCommand(int ClanId, int PlayerId, RankClan Rank) : ICommand;
