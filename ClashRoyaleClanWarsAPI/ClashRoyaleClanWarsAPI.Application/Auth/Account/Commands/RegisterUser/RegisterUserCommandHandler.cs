using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;
using ClashRoyaleClanWarsAPI.Application.Auth.Response;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Auth;
using ClashRoyaleClanWarsAPI.Domain.Errors;
using ClashRoyaleClanWarsAPI.Domain.Exceptions.Auth;
using ClashRoyaleClanWarsAPI.Domain.Shared;

namespace ClashRoyaleClanWarsAPI.Application.Auth.Account.Commands.RegisterUser;

internal class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, string>
{
    private readonly IAccountRepository _repository;

    public RegisterUserCommandHandler(IAccountRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<string>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        UserResponse response;
        try
        {
            response = await _repository.RegisterUserAsync(request.RegisterModel, request.Role);
        }
        catch (DuplicationUsernameException)
        {
            return Result.Failure<string>(ErrorTypes.Auth.DuplicateUsername());
        }
        catch (UserCreationException)
        {
            return Result.Failure<string>(ErrorTypes.Auth.InvalidCredentials());
        }

        return response.Id!;
    }
}
