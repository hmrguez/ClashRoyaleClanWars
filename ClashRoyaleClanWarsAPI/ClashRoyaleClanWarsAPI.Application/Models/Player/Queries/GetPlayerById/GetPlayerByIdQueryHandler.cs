using ClashRoyaleClanWarsAPI.Application.Common.Queries.GetModelById;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;
using ClashRoyaleClanWarsAPI.Domain.Models;

namespace ClashRoyaleClanWarsAPI.Application.Models.Player.Queries.GetPlayerById;

internal class GetPlayerByIdQueryHandler : GetModelByIdQueryHandler<PlayerModel, int>
{
    public GetPlayerByIdQueryHandler(IPlayerRepository repository) : base(repository)
    {
    }
}
