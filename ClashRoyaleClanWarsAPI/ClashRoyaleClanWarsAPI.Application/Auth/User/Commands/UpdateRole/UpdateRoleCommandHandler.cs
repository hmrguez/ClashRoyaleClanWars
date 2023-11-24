using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Auth;
using ClashRoyaleClanWarsAPI.Domain.Exceptions;
using ClashRoyaleClanWarsAPI.Domain.Shared;
using ClashRoyaleClanWarsAPI.Domain.Errors;

namespace ClashRoyaleClanWarsAPI.Application.Auth.User.Commands.UpdateRole;

internal class UpdateRoleCommandHandler : ICommandHandler<UpdateRoleCommand>
{
    private readonly IUserRepository _userRepository;

    public UpdateRoleCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _userRepository.UpdateRole(request.Id, request.Role);
        }
        catch (IdNotFoundException<string> e)
        {
            return Result.Failure(ErrorTypes.Models.IdNotFound(e.Message));
        }

        return Result.Success();
    }
}
