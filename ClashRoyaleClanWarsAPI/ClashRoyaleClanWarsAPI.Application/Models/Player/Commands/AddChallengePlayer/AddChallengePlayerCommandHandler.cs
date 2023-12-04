using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;
using ClashRoyaleClanWarsAPI.Domain.Exceptions;
using ClashRoyaleClanWarsAPI.Domain.Shared;
using ClashRoyaleClanWarsAPI.Domain.Errors;
using ClashRoyaleClanWarsAPI.Domain.Exceptions.Models;

namespace ClashRoyaleClanWarsAPI.Application.Models.Player.Commands.AddChallengePlayer;

internal class AddChallengePlayerCommandHandler : ICommandHandler<AddChallengePlayerCommand>
{
    private readonly IPlayerRepository _playerRepository;

    public AddChallengePlayerCommandHandler(IPlayerRepository playerRepository)
    {
        _playerRepository = playerRepository;
    }

    public async Task<Result> Handle(AddChallengePlayerCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _playerRepository.AddPlayerChallenge(request.PlayerId, request.ChallengeId, request.Reward);
        }
        catch (DuplicationIdException e)
        {
            return Result.Failure(ErrorTypes.Models.DuplicateId(e.Message));
        }
        catch (ChallengeClosedException)
        {
            return Result.Failure(ErrorTypes.Models.ChallengeClosed());
        }
        catch (PlayerHasNoEnoughLevelException e)
        {
            return Result.Failure(ErrorTypes.Models.PlayerHasNoEnoughLevel(e.Message));
        }

        return Result.Success();
    }
}
