using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;
using ClashRoyaleClanWarsAPI.Domain.Errors;
using ClashRoyaleClanWarsAPI.Domain.Exceptions;
using ClashRoyaleClanWarsAPI.Domain.Exceptions.Models;
using ClashRoyaleClanWarsAPI.Domain.Shared;

namespace ClashRoyaleClanWarsAPI.Application.Models.Clan.Commands.AddClanWithCreator;

public class AddClanWithCreatorCommandHandler : ICommandHandler<AddClanWithCreatorCommand, int>
{
    private readonly IClanRepository _repository;

    public AddClanWithCreatorCommandHandler(IClanRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<int>> Handle(AddClanWithCreatorCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _repository.Add(request.PlayerId, request.Clan);
        }
        catch (IdNotFoundException<int> e)
        {
            return Result.Failure<int>(ErrorTypes.Models.IdNotFound(e.Message));
        }
        catch (PlayerHasClanException)
        {
            return Result.Failure<int>(ErrorTypes.Models.PlayerHasClan());
        }

        return request.Clan.Id;
    }
}
