using ClashRoyaleClanWarsAPI.Application.Common.Queries.GetAllModel;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;
using ClashRoyaleClanWarsAPI.Domain.Models;

namespace ClashRoyaleClanWarsAPI.Application.Models.War.Queries;

public class GetAllWarQueryHandler : GetAllModelQueryHandler<WarModel, int>
{
    public GetAllWarQueryHandler(IWarRepository repository) : base(repository)
    {
    }
}
