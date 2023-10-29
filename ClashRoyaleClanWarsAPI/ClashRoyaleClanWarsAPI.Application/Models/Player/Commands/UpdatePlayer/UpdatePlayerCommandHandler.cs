using ClashRoyaleClanWarsAPI.Application.Common.Commands.UpdateModel;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;
using ClashRoyaleClanWarsAPI.Domain.Models;

namespace ClashRoyaleClanWarsAPI.Application.Models.Player.Commands.UpdatePlayer;

public class UpdatePlayerCommandHandler : UpdateModelCommandHandler<PlayerModel, int>
{
    public UpdatePlayerCommandHandler(IPlayerRepository repository) : base(repository)
    {
    }
}
