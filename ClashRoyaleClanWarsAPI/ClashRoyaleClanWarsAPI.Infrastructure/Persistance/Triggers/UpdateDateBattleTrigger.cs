using ClashRoyaleClanWarsAPI.Domain.Models.Battle;
using EntityFrameworkCore.Triggered;

namespace ClashRoyaleClanWarsAPI.Infrastructure.Persistance.Triggers;

public class UpdateDateBattleTrigger : IBeforeSaveTrigger<BattleModel>
{
    public Task BeforeSave(ITriggerContext<BattleModel> context, CancellationToken cancellationToken)
    {
        if (context.ChangeType == ChangeType.Added)
        {
            context.Entity.AddDate();
        }

        return Task.CompletedTask;
    }
}
