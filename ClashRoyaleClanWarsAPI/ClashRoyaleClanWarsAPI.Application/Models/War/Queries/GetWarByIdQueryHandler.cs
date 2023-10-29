using ClashRoyaleClanWarsAPI.Application.Common.Queries.GetModelById;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;
using ClashRoyaleClanWarsAPI.Domain.Models;

namespace ClashRoyaleClanWarsAPI.Application.Models.War.Queries;

public class GetWarByIdQueryHandler : GetModelByIdQueryHandler<WarModel, int>
{
    public GetWarByIdQueryHandler(IWarRepository repository) : base(repository)
    {
    }
}
