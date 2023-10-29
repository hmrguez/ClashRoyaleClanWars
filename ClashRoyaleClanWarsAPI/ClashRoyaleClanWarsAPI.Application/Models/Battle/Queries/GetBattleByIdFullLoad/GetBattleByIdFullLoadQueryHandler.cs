using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;
using ClashRoyaleClanWarsAPI.Domain.Errors;
using ClashRoyaleClanWarsAPI.Domain.Exceptions;
using ClashRoyaleClanWarsAPI.Domain.Models.Battle;
using ClashRoyaleClanWarsAPI.Domain.Shared;

namespace ClashRoyaleClanWarsAPI.Application.Models.Battle.Queries.GetBattleByIdFullLoad;

public class GetBattleByIdFullLoadQueryHandler : IQueryHandler<GetBattleByIdFullLoadQuery, BattleModel>
{
    private readonly IBattleRepository _repository;

    public GetBattleByIdFullLoadQueryHandler(IBattleRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<BattleModel>> Handle(GetBattleByIdFullLoadQuery request, CancellationToken cancellationToken)
    {
        BattleModel battle;
        try
        {
            battle = await _repository.GetSingleByIdAsync(request.Id, request.FullLoad);
        }
        catch (IdNotFoundException<Guid> e)
        {
            return Result.Failure<BattleModel>(ErrorTypes.Models.IdNotFound(e.Message));
        }

        return battle;
    }
}
