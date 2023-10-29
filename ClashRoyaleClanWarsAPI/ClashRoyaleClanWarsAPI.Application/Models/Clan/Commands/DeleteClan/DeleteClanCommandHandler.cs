using ClashRoyaleClanWarsAPI.Application.Common.Commands.DeleteModel;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;
using ClashRoyaleClanWarsAPI.Domain.Models;

namespace ClashRoyaleClanWarsAPI.Application.Models.Clan.Commands.DeleteClan;

public class DeleteClanCommandHandler : DeleteModelCommandHandler<ClanModel, int>
{
    public DeleteClanCommandHandler(IClanRepository repository) : base(repository)
    {
    }
}
