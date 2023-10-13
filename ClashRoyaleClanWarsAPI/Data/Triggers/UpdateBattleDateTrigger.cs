using ClashRoyaleClanWarsAPI.Models;
using EntityFrameworkCore.Triggered;

namespace ClashRoyaleClanWarsAPI.Data.Triggers
{
    public class UpdateBattleDateTrigger : IBeforeSaveTrigger<BattleModel>
    {
        public Task BeforeSave(ITriggerContext<BattleModel> context, CancellationToken cancellationToken)
        {
            if (context.ChangeType == ChangeType.Added)
            {
                context.Entity.Date = DateTime.UtcNow;
            }

            return Task.CompletedTask;
        }
    }
}
