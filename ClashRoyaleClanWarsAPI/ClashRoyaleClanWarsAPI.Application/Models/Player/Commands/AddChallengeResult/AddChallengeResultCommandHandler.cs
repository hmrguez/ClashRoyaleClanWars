using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;
using ClashRoyaleClanWarsAPI.Domain.Exceptions;
using ClashRoyaleClanWarsAPI.Domain.Shared;
using ClashRoyaleClanWarsAPI.Domain.Errors;
using ClashRoyaleClanWarsAPI.Domain.Exceptions.Models;

namespace ClashRoyaleClanWarsAPI.Application.Models.Player.Commands.AddChallengeResult;

internal class AddChallengeResultCommandHandler : ICommandHandler<AddChallengeResultCommand>
{
    private readonly IPlayerRepository _playerRepository;

    public AddChallengeResultCommandHandler(IPlayerRepository playerRepository)
    {
        _playerRepository = playerRepository;
    }

    public async Task<Result> Handle(AddChallengeResultCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _playerRepository.AddChallengeResult(request.PlayerId, request.ChallengeId, request.Reward);
        }
        catch (IdNotFoundException<int> e)
        {
            return Result.Failure(ErrorTypes.Models.IdNotFound(e.Message));
        }
        catch (ChallengeClosedException)
        {
            return Result.Failure(ErrorTypes.Models.ChallengeClosed());
        }

        return Result.Success();
    }
}
