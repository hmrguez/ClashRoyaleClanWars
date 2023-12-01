using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;
using ClashRoyaleClanWarsAPI.Application.Auth.Response;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Auth;
using ClashRoyaleClanWarsAPI.Domain.Shared;

namespace ClashRoyaleClanWarsAPI.Application.Auth.User.Queries.GetAllUser;

public class GetAllUserQueryHandler : IQueryHandler<GetAllUserQuery, IEnumerable<UserResponse>>
{
    private readonly IUserRepository _repository;

    public GetAllUserQueryHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<IEnumerable<UserResponse>>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
    {
        var users = await _repository.GetAllAsync();

        var userResponse = users.Select(u => UserResponse.Create(u.Id, u.UserName, u.Role!.Name, u.PlayerId)).ToList();

        return Result.Create(userResponse.AsEnumerable());
    }
}
