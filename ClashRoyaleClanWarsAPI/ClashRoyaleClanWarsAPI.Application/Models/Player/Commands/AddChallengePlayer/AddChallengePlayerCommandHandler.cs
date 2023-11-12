using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;
using ClashRoyaleClanWarsAPI.Domain.Shared;

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
        await _playerRepository.AddPlayerChallenge(request.PlayerId, request.ChallengeId, request.Reward);

        return Result.Success();
    }
}
