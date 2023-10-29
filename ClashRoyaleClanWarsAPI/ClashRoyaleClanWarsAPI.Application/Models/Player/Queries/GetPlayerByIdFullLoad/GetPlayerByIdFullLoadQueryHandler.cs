using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;
using ClashRoyaleClanWarsAPI.Domain.Errors;
using ClashRoyaleClanWarsAPI.Domain.Exceptions;
using ClashRoyaleClanWarsAPI.Domain.Models;
using ClashRoyaleClanWarsAPI.Domain.Shared;

namespace ClashRoyaleClanWarsAPI.Application.Models.Player.Queries.GetPlayerByIdFullLoad;

internal class GetPlayerByIdFullLoadQueryHandler : IQueryHandler<GetPlayerByIdFullLoadQuery, PlayerModel>
{
    private readonly IPlayerRepository _repository;

    public GetPlayerByIdFullLoadQueryHandler(IPlayerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<PlayerModel>> Handle(GetPlayerByIdFullLoadQuery request, CancellationToken cancellationToken)
    {
        PlayerModel player;
        try
        {
            player = await _repository.GetSingleByIdAsync(request.Id, request.FullLoad);
        }
        catch (IdNotFoundException<int> e)
        {
            return Result.Failure<PlayerModel>(ErrorTypes.Models.IdNotFound(e.Message));
        }

        return player;
    }
}
