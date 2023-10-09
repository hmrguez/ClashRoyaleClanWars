using ClashRoyaleClanWarsAPI.Interfaces.ServicesInterfaces;
using ClashRoyaleClanWarsAPI.Models;
using EntityFrameworkCore.Triggered;

namespace ClashRoyaleClanWarsAPI.Data.Triggers
{
    public class UpdateMaxEloInBattleTrigger : IBeforeSaveTrigger<BattleModel>
    {
        private readonly IPlayerService _playerService;

        public UpdateMaxEloInBattleTrigger(IPlayerService playerService)
        {
            _playerService = playerService;
        }
        public async Task BeforeSave(ITriggerContext<BattleModel> context, CancellationToken cancellationToken)
        {
            if (context.ChangeType == ChangeType.Added)
            {
                var player = await _playerService.GetSingleByIdAsync(context.Entity.Winner.Id);
                player.Elo += context.Entity.AmountTrophies;
                if (player.Elo > player.MaxElo)
                    player.MaxElo = player.Elo;
            }
        }
    }
}
