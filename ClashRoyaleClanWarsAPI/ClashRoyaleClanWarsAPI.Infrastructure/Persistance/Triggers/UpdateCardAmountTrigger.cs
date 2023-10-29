using ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;
using ClashRoyaleClanWarsAPI.Domain.Relationships;
using EntityFrameworkCore.Triggered;

namespace ClashRoyaleClanWarsAPI.Infrastructure.Persistance.Triggers;

public class UpdateCardAmountTrigger : IAfterSaveTrigger<CollectionModel>
{
    private readonly IPlayerRepository _playerService;

    public UpdateCardAmountTrigger(IPlayerRepository playerService)
    {
        _playerService = playerService;
    }
    public async Task AfterSave(ITriggerContext<CollectionModel> context, CancellationToken cancellationToken)
    {

        if (context.ChangeType == ChangeType.Added && context.Entity.Player is not null)
        {
            var player = await _playerService.GetSingleByIdAsync(context.Entity.Player.Id);
            player!.AddCardAmount();
            await _playerService.Save();

        }
    }
}
