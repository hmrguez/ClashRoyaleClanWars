using ClashRoyaleClanWarsAPI.Models;
using EntityFrameworkCore.Triggered;

namespace ClashRoyaleClanWarsAPI.Data.Triggers
{
    public class UpdateMaxEloAddPlayerDto : IBeforeSaveTrigger<PlayerModel>
    {
        public Task BeforeSave(ITriggerContext<PlayerModel> context, CancellationToken cancellationToken)
        {
            if(context.ChangeType == ChangeType.Added)
            {
                context.Entity.MaxElo = context.Entity.Elo;
            }
            return Task.CompletedTask;
        }
    }
}
