using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;
using ClashRoyaleClanWarsAPI.Domain.Errors;
using ClashRoyaleClanWarsAPI.Domain.Exceptions;
using ClashRoyaleClanWarsAPI.Domain.Shared;

namespace ClashRoyaleClanWarsAPI.Application.Models.Player.Commands.AddCard;

public class AddCardCommandHandler : ICommandHandler<AddCardCommand>
{
    private readonly IPlayerRepository _repository;

    public AddCardCommandHandler(IPlayerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result> Handle(AddCardCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _repository.AddCard(request.PlayerId, request.CardId);
        }
        catch (DuplicationIdException e)
        {
            return Result.Failure(ErrorTypes.Models.DuplicateId(e.Message));
        }

        return Result.Success();
    }
}
