using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;
using ClashRoyaleClanWarsAPI.Domain.Models;
using ClashRoyaleClanWarsAPI.Domain.Shared;

namespace ClashRoyaleClanWarsAPI.Application.Models.Player.Queries.GetAllPlayerByAlias;

public class GetAllPlayerByAliasQueryHandler : IQueryHandler<GetAllPlayerByAliasQuery, IEnumerable<PlayerModel>>
{
    private readonly IPlayerRepository _playerRepository;

    public GetAllPlayerByAliasQueryHandler(IPlayerRepository playerRepository)
    {
        _playerRepository = playerRepository;
    }

    public async Task<Result<IEnumerable<PlayerModel>>> Handle(GetAllPlayerByAliasQuery request, CancellationToken cancellationToken)
    {
        var players = await _playerRepository.GetPlayersByAliasAsync(request.Alias);

        return Result.Create(players);
    }
}
