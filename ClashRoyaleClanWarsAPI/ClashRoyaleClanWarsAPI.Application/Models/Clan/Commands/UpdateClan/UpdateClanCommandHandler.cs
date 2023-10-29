using ClashRoyaleClanWarsAPI.Application.Common.Commands.UpdateModel;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;
using ClashRoyaleClanWarsAPI.Domain.Models;

namespace ClashRoyaleClanWarsAPI.Application.Models.Clan.Commands.UpdateClan;

public class UpdateClanCommandHandler : UpdateModelCommandHandler<ClanModel, int>
{
    public UpdateClanCommandHandler(IClanRepository repository) : base(repository)
    {
    }
}
