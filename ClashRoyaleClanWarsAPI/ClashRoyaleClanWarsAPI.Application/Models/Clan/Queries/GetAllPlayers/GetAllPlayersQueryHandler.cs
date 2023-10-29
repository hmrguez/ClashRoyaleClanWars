using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;
using ClashRoyaleClanWarsAPI.Domain.Errors;
using ClashRoyaleClanWarsAPI.Domain.Exceptions;
using ClashRoyaleClanWarsAPI.Domain.Relationships;
using ClashRoyaleClanWarsAPI.Domain.Shared;

namespace ClashRoyaleClanWarsAPI.Application.Models.Clan.Queries.GetAllPlayers;

public class GetAllPlayersQueryHandler : IQueryHandler<GetAllPlayersQuery, IEnumerable<ClanPlayersModel>>
{
    private readonly IClanRepository _repository;

    public GetAllPlayersQueryHandler(IClanRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<IEnumerable<ClanPlayersModel>>> Handle(GetAllPlayersQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<ClanPlayersModel> players;

        try
        {
            players = await _repository.GetPlayers(request.ClanId);
        }
        catch (IdNotFoundException<int> e)
        {
            return Result.Failure<IEnumerable<ClanPlayersModel>>(ErrorTypes.Models.IdNotFound(e.Message));
        }

        return Result.Create(players);
    }
}
