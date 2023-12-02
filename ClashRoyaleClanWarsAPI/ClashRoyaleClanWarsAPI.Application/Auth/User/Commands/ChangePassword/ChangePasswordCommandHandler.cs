using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Auth;
using ClashRoyaleClanWarsAPI.Domain.Exceptions;
using ClashRoyaleClanWarsAPI.Domain.Shared;
using ClashRoyaleClanWarsAPI.Domain.Errors;

namespace ClashRoyaleClanWarsAPI.Application.Auth.User.Commands.ChangePassword;

internal class ChangePasswordCommandHandler : ICommandHandler<ChangePasswordCommand>
{
    private readonly IUserRepository _userRepository;

    public ChangePasswordCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _userRepository.ChangePassword(request.Id, request.Password);
        }
        catch (IdNotFoundException<int> e)
        {
            return Result.Failure(ErrorTypes.Models.IdNotFound(e.Message));
        }

        return Result.Success();
    }
}
