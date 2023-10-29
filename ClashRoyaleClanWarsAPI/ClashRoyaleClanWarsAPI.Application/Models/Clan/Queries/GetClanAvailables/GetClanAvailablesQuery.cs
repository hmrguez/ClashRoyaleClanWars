using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;
using ClashRoyaleClanWarsAPI.Domain.Models;

namespace ClashRoyaleClanWarsAPI.Application.Models.Clan.Queries.GetClanAvailables;

public record GetClanAvailablesQuery(int Trophies) : IQuery<IEnumerable<ClanModel>>;
