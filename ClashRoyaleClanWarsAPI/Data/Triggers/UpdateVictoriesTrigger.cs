using ClashRoyaleClanWarsAPI.Interfaces.ServicesInterfaces;
using ClashRoyaleClanWarsAPI.Models;
using EntityFrameworkCore.Triggered;

namespace ClashRoyaleClanWarsAPI.Data.Triggers
{
    public class UpdateVictoriesTrigger : IBeforeSaveTrigger<BattleModel>
    {
        private readonly IPlayerService _playerService;

        public UpdateVictoriesTrigger(IPlayerService playerService)
        {
            _playerService = playerService;
        }
        public async Task BeforeSave(ITriggerContext<BattleModel> context, CancellationToken cancellationToken)
        {
            if(context.ChangeType == ChangeType.Added)
            {
                var player = await _playerService.GetSingleByIdAsync(context.Entity.Winner.Id);
                player.Victories += 1;
            }
        }
    }
}
