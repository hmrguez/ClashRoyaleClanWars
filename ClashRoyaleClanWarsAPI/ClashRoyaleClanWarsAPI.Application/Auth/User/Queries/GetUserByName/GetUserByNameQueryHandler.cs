using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;
using ClashRoyaleClanWarsAPI.Application.Auth.Response;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Auth;
using ClashRoyaleClanWarsAPI.Domain.Errors;
using ClashRoyaleClanWarsAPI.Domain.Exceptions.Auth;
using ClashRoyaleClanWarsAPI.Domain.Shared;

namespace ClashRoyaleClanWarsAPI.Application.Auth.User.Queries.GetUserByName;

internal class GetUserByNameQueryHandler : IQueryHandler<GetUserByNameQuery, UserResponse>
{
    private readonly IUserRepository _repository;

    public GetUserByNameQueryHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<UserResponse>> Handle(GetUserByNameQuery request, CancellationToken cancellationToken)
    {
        UserResponse response;

        try
        {
            response = await _repository.GetUserByNameAsync(request.Name);
        }
        catch (UsernameNotFoundException)
        {
            return Result.Failure<UserResponse>(ErrorTypes.Auth.UsernameNotFound());
        }

        return response;
    }
}
