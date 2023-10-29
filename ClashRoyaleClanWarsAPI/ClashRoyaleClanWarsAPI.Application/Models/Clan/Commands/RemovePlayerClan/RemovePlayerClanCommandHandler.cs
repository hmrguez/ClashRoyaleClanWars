using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;
using ClashRoyaleClanWarsAPI.Domain.Errors;
using ClashRoyaleClanWarsAPI.Domain.Exceptions;
using ClashRoyaleClanWarsAPI.Domain.Shared;

namespace ClashRoyaleClanWarsAPI.Application.Models.Clan.Commands.RemovePlayerClan;

public class RemovePlayerClanCommandHandler : ICommandHandler<RemovePlayerClanCommand>
{
    private readonly IClanRepository _repository;

    public RemovePlayerClanCommandHandler(IClanRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result> Handle(RemovePlayerClanCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _repository.RemovePlayer(request.ClanId, request.PlayerId);
        }
        catch (IdNotFoundException<int> e)
        {
            return Result.Failure(ErrorTypes.Models.IdNotFound(e.Message));
        }

        return Result.Success();
    }
}
