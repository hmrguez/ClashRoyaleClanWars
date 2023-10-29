using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;
using ClashRoyaleClanWarsAPI.Domain.Models;
using ClashRoyaleClanWarsAPI.Domain.Shared;

namespace ClashRoyaleClanWarsAPI.Application.Models.Clan.Queries.GetAllClanByName;

public class GetAllClanByNameQueryHandler : IQueryHandler<GetAllClanByNameQuery, IEnumerable<ClanModel>>
{
    private readonly IClanRepository _repository;

    public GetAllClanByNameQueryHandler(IClanRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<IEnumerable<ClanModel>>> Handle(GetAllClanByNameQuery request, CancellationToken cancellationToken)
    {
        var clans = await _repository.GetAllByName(request.Name);

        return Result.Create(clans);
    }
}
