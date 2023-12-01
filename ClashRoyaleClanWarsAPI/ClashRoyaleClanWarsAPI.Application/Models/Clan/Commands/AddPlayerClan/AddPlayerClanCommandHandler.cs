using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;
using ClashRoyaleClanWarsAPI.Domain.Errors;
using ClashRoyaleClanWarsAPI.Domain.Exceptions;
using ClashRoyaleClanWarsAPI.Domain.Exceptions.Models;
using ClashRoyaleClanWarsAPI.Domain.Shared;

namespace ClashRoyaleClanWarsAPI.Application.Models.Clan.Commands.AddPlayerClan;

public class AddPlayerClanCommandHandler : ICommandHandler<AddPlayerClanCommand>
{
    private readonly IClanRepository _repository;

    public AddPlayerClanCommandHandler(IClanRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result> Handle(AddPlayerClanCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _repository.AddPlayer(request.ClanId, request.PlayerId);
        }
        catch (IdNotFoundException<int> e)
        {
            return Result.Failure(ErrorTypes.Models.IdNotFound(e.Message));
        }
        catch (DuplicationIdException e)
        {
            return Result.Failure(ErrorTypes.Models.DuplicateId(e.Message));
        }
        catch (PlayerHasClanException)
        {
            return Result.Failure(ErrorTypes.Models.PlayerHasClan());
        }
        catch (PlayerHasNoEnoughTrophiesException e)
        {
            return Result.Failure(ErrorTypes.Models.PlayerHasNoEnoughTrophies(e.Message));
        }

        return Result.Success();
    }
}
