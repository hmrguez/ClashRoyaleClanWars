using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;
using ClashRoyaleClanWarsAPI.Domain.Models;
using ClashRoyaleClanWarsAPI.Domain.Shared;

namespace ClashRoyaleClanWarsAPI.Application.Models.War.Queries.GetUpCommingWars;

public class GetUpComingWarsQueryHandler : IQueryHandler<GetUpComingWarsQuery, IEnumerable<WarModel>>
{
    private readonly IWarRepository _repository;

    public GetUpComingWarsQueryHandler(IWarRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<IEnumerable<WarModel>>> Handle(GetUpComingWarsQuery request, CancellationToken cancellationToken)
    {
        var upcomingsWars = await _repository.GetWarsByDate(request.Date);

        return Result.Create(upcomingsWars);
    }
}
