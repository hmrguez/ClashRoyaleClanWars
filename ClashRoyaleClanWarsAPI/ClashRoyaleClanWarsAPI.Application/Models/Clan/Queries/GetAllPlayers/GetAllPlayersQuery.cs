using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;
using ClashRoyaleClanWarsAPI.Domain.Relationships;

namespace ClashRoyaleClanWarsAPI.Application.Models.Clan.Queries.GetAllPlayers;

public record GetAllPlayersQuery(int ClanId) : IQuery<IEnumerable<ClanPlayersModel>>;
