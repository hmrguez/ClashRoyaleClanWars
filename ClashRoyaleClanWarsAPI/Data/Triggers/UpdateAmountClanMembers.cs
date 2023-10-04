using ClashRoyaleClanWarsAPI.Interfaces.ServicesInterfaces;
using ClashRoyaleClanWarsAPI.Models;
using EntityFrameworkCore.Triggered;

namespace ClashRoyaleClanWarsAPI.Data.Triggers
{
    public class UpdateAmountClanMembers : IAfterSaveTrigger<PlayerClansModel>
    {
        private readonly IClanService _clanService;

        public UpdateAmountClanMembers(IClanService clanService)
        {
            _clanService = clanService;
        }
        public async Task AfterSave(ITriggerContext<PlayerClansModel> context, CancellationToken cancellationToken)
        {
            if(context.ChangeType == ChangeType.Added)
            {
                var clan = await _clanService.GetSingleByIdAsync(context.Entity.Clan.Id);
                clan.AmountMembers += 1;
                await _clanService.Save();
            }
        }
    }
}
