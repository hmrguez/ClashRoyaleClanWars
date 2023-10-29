using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;
using ClashRoyaleClanWarsAPI.Domain.Models;

namespace ClashRoyaleClanWarsAPI.Application.Models.Clan.Queries.GetAllClanByName;

public record GetAllClanByNameQuery(string Name) : IQuery<IEnumerable<ClanModel>>;
