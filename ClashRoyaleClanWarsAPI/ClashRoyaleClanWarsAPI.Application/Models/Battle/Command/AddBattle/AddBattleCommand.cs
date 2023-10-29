using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;
using ClashRoyaleClanWarsAPI.Domain.Models.Battle;

namespace ClashRoyaleClanWarsAPI.Application.Models.Battle.Command.AddBattle;

public record AddBattleCommand(BattleModel Battle, int WinnerId, int LoserId) : ICommand<Guid>;
