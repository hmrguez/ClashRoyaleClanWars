using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;
using ClashRoyaleClanWarsAPI.Domain.Models.Battle;

namespace ClashRoyaleClanWarsAPI.Application.Models.Battle.Queries.GetAllBattleInclude;

public record GetAllBattleIncludeQuery() : IQuery<IEnumerable<BattleModel>>;
