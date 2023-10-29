using ClashRoyaleClanWarsAPI.Application.Common.Commands.DeleteModel;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;
using ClashRoyaleClanWarsAPI.Domain.Models;

namespace ClashRoyaleClanWarsAPI.Application.Models.Player.Commands.DeletePlayer;

public class DeletePlayerCommandHandler : DeleteModelCommandHandler<PlayerModel, int>
{
    public DeletePlayerCommandHandler(IPlayerRepository repository) : base(repository)
    {
    }
}
