using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;
using ClashRoyaleClanWarsAPI.Domain.Errors;
using ClashRoyaleClanWarsAPI.Domain.Exceptions;
using ClashRoyaleClanWarsAPI.Domain.Shared;

namespace ClashRoyaleClanWarsAPI.Application.Models.Battle.Command.AddBattle;

public class AddBattleCommandHandler : ICommandHandler<AddBattleCommand, Guid>
{
    private readonly IBattleRepository _repository;

    public AddBattleCommandHandler(IBattleRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Guid>> Handle(AddBattleCommand request, CancellationToken cancellationToken)
    {
        Guid id;
        try
        {
            id = await _repository.Add(request.Battle, request.WinnerId, request.LoserId);
        }
        catch (IdNotFoundException<int> e)
        {
            return Result.Failure<Guid>(ErrorTypes.Models.IdNotFound(e.Message));
        }
        catch (DuplicationIdException e)
        {
            return Result.Failure<Guid>(ErrorTypes.Models.DuplicateId(e.Message));
        }

        return id;

    }
}
