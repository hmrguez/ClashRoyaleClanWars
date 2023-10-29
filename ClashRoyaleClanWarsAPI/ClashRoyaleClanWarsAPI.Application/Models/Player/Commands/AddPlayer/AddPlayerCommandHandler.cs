using ClashRoyaleClanWarsAPI.Application.Common.Commands.AddModel;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;
using ClashRoyaleClanWarsAPI.Domain.Models;

namespace ClashRoyaleClanWarsAPI.Application.Models.Player.Commands.AddPlayer;

public class AddPlayerCommandHandler : AddModelCommandHandler<PlayerModel, int>
{
    public AddPlayerCommandHandler(IPlayerRepository repository) : base(repository)
    {
    }
}
