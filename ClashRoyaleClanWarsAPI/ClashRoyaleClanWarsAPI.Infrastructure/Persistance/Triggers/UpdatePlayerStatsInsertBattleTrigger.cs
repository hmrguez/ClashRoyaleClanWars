using ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;
using ClashRoyaleClanWarsAPI.Domain.Models.Battle;
using EntityFrameworkCore.Triggered;

namespace ClashRoyaleClanWarsAPI.Infrastructure.Persistance.Triggers;

public class UpdatePlayerStatsInsertBattleTrigger : IBeforeSaveTrigger<BattleModel>
{
    private readonly IPlayerRepository _repository;

    public UpdatePlayerStatsInsertBattleTrigger(IPlayerRepository repository)
    {
        _repository = repository;
    }
    public async Task BeforeSave(ITriggerContext<BattleModel> context, CancellationToken cancellationToken)
    {
        if (context.ChangeType == ChangeType.Added && context.Entity.Winner is not null && context.Entity.Loser is not null)
        {
            var winner = await _repository.GetSingleByIdAsync(context.Entity.Winner.Id);
            var loser = await _repository.GetSingleByIdAsync(context.Entity.Loser.Id);

            winner!.AddVictory();

            loser!.UpdateElo(-context.Entity.AmountTrophies);
            winner!.UpdateElo(context.Entity.AmountTrophies);
        }
    }
}
