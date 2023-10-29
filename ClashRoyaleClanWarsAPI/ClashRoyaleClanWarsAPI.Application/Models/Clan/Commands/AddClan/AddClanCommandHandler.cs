using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;
using ClashRoyaleClanWarsAPI.Domain.Errors;
using ClashRoyaleClanWarsAPI.Domain.Exceptions;
using ClashRoyaleClanWarsAPI.Domain.Shared;

namespace ClashRoyaleClanWarsAPI.Application.Models.Clan.Commands.AddClan;

public class AddClanCommandHandler : ICommandHandler<AddClanCommand, int>
{
    private readonly IClanRepository _repository;

    public AddClanCommandHandler(IClanRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<int>> Handle(AddClanCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _repository.Add(request.PlayerId, request.Clan);
        }
        catch (IdNotFoundException<int> e)
        {
            return Result.Failure<int>(ErrorTypes.Models.IdNotFound(e.Message));
        }

        return request.Clan.Id;
    }
}
