using ClashRoyaleClanWarsAPI.Application.Common.Queries.GetAllModel;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;
using ClashRoyaleClanWarsAPI.Domain.Models;

namespace ClashRoyaleClanWarsAPI.Application.Models.Player.Queries.GetAllPlayer;

public class GetAllPlayerQueryHandler : GetAllModelQueryHandler<PlayerModel, int>
{
    public GetAllPlayerQueryHandler(IPlayerRepository repository) : base(repository)
    {
    }
}
