using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;
using ClashRoyaleClanWarsAPI.Domain.Models;

namespace ClashRoyaleClanWarsAPI.Application.Models.Player.Queries.GetAllPlayerByAlias;

public record GetAllPlayerByAliasQuery(string Alias) : IQuery<IEnumerable<PlayerModel>>;
