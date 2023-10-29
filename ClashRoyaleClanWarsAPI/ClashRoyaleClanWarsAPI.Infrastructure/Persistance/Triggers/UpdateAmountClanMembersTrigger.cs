using ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;
using ClashRoyaleClanWarsAPI.Domain.Relationships;
using EntityFrameworkCore.Triggered;

namespace ClashRoyaleClanWarsAPI.Infrastructure.Persistance.Triggers;

public class UpdateAmountClanMembersTrigger : IBeforeSaveTrigger<ClanPlayersModel>
{
    private readonly IClanRepository _clanRepository;

    public UpdateAmountClanMembersTrigger(IClanRepository clanRepository)
    {
        _clanRepository = clanRepository;
    }
    public async Task BeforeSave(ITriggerContext<ClanPlayersModel> context, CancellationToken cancellationToken)
    {
        if (context.Entity.Clan is null)
            return;

        var clan = await _clanRepository.GetSingleByIdAsync(context.Entity.Clan.Id);

        if (context.ChangeType == ChangeType.Added)
        {
            clan!.AddAmountMember();
        }
        else if (context.ChangeType == ChangeType.Deleted)
        {
            clan!.RemoveAmountMember();
        }
        await _clanRepository.Save();
    }
}
