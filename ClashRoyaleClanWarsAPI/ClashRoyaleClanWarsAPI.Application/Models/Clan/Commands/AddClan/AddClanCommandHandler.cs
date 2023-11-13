using ClashRoyaleClanWarsAPI.Application.Common.Commands.AddModel;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;
using ClashRoyaleClanWarsAPI.Domain.Models;

namespace ClashRoyaleClanWarsAPI.Application.Models.Clan.Commands.AddClan;

internal class AddClanCommandHandler : AddModelCommandHandler<ClanModel, int>
{
    public AddClanCommandHandler(IClanRepository repository) : base(repository)
    {
    }
}
