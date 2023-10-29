using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;
using ClashRoyaleClanWarsAPI.Domain.Errors;
using ClashRoyaleClanWarsAPI.Domain.Exceptions;
using ClashRoyaleClanWarsAPI.Domain.Models;
using ClashRoyaleClanWarsAPI.Domain.Shared;

namespace ClashRoyaleClanWarsAPI.Application.Models.Clan.Queries.GetClanByIdFullLoad;

public class GetClanByIdFullLoadQueryHandler : IQueryHandler<GetClanByIdFullLoadQuery, ClanModel>
{
    private readonly IClanRepository _repository;

    public GetClanByIdFullLoadQueryHandler(IClanRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ClanModel>> Handle(GetClanByIdFullLoadQuery request, CancellationToken cancellationToken)
    {
        ClanModel clan;
        try
        {
            clan = await _repository.GetSingleByIdAsync(request.Id, true);
        }
        catch (IdNotFoundException<int> e)
        {
            return Result.Failure<ClanModel>(ErrorTypes.Models.IdNotFound(e.Message));
        }

        return clan!;
    }
}
