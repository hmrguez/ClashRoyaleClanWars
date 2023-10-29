using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;
using ClashRoyaleClanWarsAPI.Domain.Models;
using ClashRoyaleClanWarsAPI.Domain.Shared;

namespace ClashRoyaleClanWarsAPI.Application.Models.Clan.Queries.GetClanAvailables;

public class GetClanAvailablesQueryHandler : IQueryHandler<GetClanAvailablesQuery, IEnumerable<ClanModel>>
{
    private readonly IClanRepository _repository;

    public GetClanAvailablesQueryHandler(IClanRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<IEnumerable<ClanModel>>> Handle(GetClanAvailablesQuery request, CancellationToken cancellationToken)
    {
        var clans = await _repository.GetAllAvailable(request.Trophies);

        return Result.Create(clans);
    }
}
