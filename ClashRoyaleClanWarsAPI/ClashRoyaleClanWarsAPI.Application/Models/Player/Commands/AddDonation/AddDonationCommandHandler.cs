using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;
using ClashRoyaleClanWarsAPI.Domain.Exceptions;
using ClashRoyaleClanWarsAPI.Domain.Shared;
using ClashRoyaleClanWarsAPI.Domain.Errors;
using ClashRoyaleClanWarsAPI.Domain.Exceptions.Models;

namespace ClashRoyaleClanWarsAPI.Application.Models.Player.Commands.AddDonation;

internal class AddDonationCommandHandler : ICommandHandler<AddDonationCommand>
{
    private readonly IPlayerRepository _playerRepository;

    public AddDonationCommandHandler(IPlayerRepository playerRepository)
    {
        _playerRepository = playerRepository;
    }

    public async Task<Result> Handle(AddDonationCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _playerRepository.AddDonation(request.PlayerId, request.CardId, request.Amount, request.Date);
        }
        catch (IdNotFoundException<int> e)
        {
            return Result.Failure(ErrorTypes.Models.IdNotFound(e.Message));
        }
        catch (PlayerNotHaveCardException)
        {
            return Result.Failure(ErrorTypes.Models.PlayerNotHaveCard());
        }
        catch (PlayerHasNoClanException e)
        {
            return Result.Failure(ErrorTypes.Models.PlayerHasNoClan(e.Message));
        }

        return Result.Success();
    }
}
