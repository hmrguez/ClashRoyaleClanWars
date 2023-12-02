using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;
using ClashRoyaleClanWarsAPI.Domain.Errors;
using ClashRoyaleClanWarsAPI.Domain.Exceptions;
using ClashRoyaleClanWarsAPI.Domain.Exceptions.Models;
using ClashRoyaleClanWarsAPI.Domain.Shared;

namespace ClashRoyaleClanWarsAPI.Application.Models.War.Commands.AddClanWar;

internal class AddClanWarCommandHandler : ICommandHandler<AddClanWarCommand>
{
    private readonly IWarRepository _warRepository;

    public AddClanWarCommandHandler(IWarRepository warRepository)
    {
        _warRepository = warRepository;
    }

    public async Task<Result> Handle(AddClanWarCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _warRepository.AddClanToWar(request.WarId, request.ClanId, request.Prize);
        }
        catch (DuplicationIdException e)
        {
            return Result.Failure(ErrorTypes.Models.DuplicateId(e.Message));
        }
        catch (ClanAlreadyInWarException e)
        {
            return Result.Failure(ErrorTypes.Models.ClanAlreadyInWar(e.Message));
        }

        return Result.Success();
    }
}
