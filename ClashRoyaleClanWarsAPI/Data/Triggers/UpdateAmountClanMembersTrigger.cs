using ClashRoyaleClanWarsAPI.Interfaces.ServicesInterfaces;
using ClashRoyaleClanWarsAPI.Models;
using EntityFrameworkCore.Triggered;

namespace ClashRoyaleClanWarsAPI.Data.Triggers
{
    public class UpdateAmountClanMembersTrigger : IBeforeSaveTrigger<PlayerClansModel>
    {
        private readonly IClanService _clanService;

        public UpdateAmountClanMembersTrigger(IClanService clanService)
        {
            _clanService = clanService;
        }
        public async Task BeforeSave(ITriggerContext<PlayerClansModel> context, CancellationToken cancellationToken)
        {
            if (context.Entity.Clan is null)
                return;

            var clan = await _clanService.GetSingleByIdAsync(context.Entity.Clan.Id);
            
            if(context.ChangeType == ChangeType.Added)
            {
                clan.AmountMembers += 1;
            }
            else if (context.ChangeType == ChangeType.Deleted)
            {
                clan.AmountMembers -= 1;
            }
            await _clanService.Save();
        }
    }
}
