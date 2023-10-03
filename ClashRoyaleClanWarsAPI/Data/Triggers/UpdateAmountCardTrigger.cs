using ClashRoyaleClanWarsAPI.Interfaces.ServicesInterfaces;
using ClashRoyaleClanWarsAPI.Models;
using EntityFrameworkCore.Triggered;

namespace ClashRoyaleClanWarsAPI.Data.Triggers
{
    public class UpdateAmountCardTrigger : IAfterSaveTrigger<CollectModel>
    {
        private readonly IPlayerService _playerService;

        public UpdateAmountCardTrigger(IPlayerService playerService) 
        {
            _playerService = playerService;
        }
        public async Task AfterSave(ITriggerContext<CollectModel> context, CancellationToken cancellationToken)
        {

            if(context.ChangeType == ChangeType.Added)
            {
                var player = await _playerService.GetSingleByIdAsync(context.Entity.Player.Id);
                player.CardAmount = player.CardAmount + 1;
                await _playerService.Save();
                
            }
        }
    }
}
