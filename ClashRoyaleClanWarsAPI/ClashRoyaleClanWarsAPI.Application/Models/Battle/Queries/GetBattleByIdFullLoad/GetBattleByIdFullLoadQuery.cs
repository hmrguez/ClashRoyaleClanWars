using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;
using ClashRoyaleClanWarsAPI.Domain.Models.Battle;

namespace ClashRoyaleClanWarsAPI.Application.Models.Battle.Queries.GetBattleByIdFullLoad;

public record GetBattleByIdFullLoadQuery(Guid Id, bool FullLoad) : IQuery<BattleModel>;
