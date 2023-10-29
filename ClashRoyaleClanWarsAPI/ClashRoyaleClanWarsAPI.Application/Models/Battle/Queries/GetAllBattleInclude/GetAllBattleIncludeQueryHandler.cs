using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;
using ClashRoyaleClanWarsAPI.Domain.Models.Battle;
using ClashRoyaleClanWarsAPI.Domain.Shared;

namespace ClashRoyaleClanWarsAPI.Application.Models.Battle.Queries.GetAllBattleInclude;

public class GetAllBattleIncludeQueryHandler : IQueryHandler<GetAllBattleIncludeQuery, IEnumerable<BattleModel>>
{
    private readonly IBattleRepository _repository;

    public GetAllBattleIncludeQueryHandler(IBattleRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<IEnumerable<BattleModel>>> Handle(GetAllBattleIncludeQuery request, CancellationToken cancellationToken)
    {
        var battles = await _repository.GetAllAsync();

        return Result.Create(battles);
    }
}
