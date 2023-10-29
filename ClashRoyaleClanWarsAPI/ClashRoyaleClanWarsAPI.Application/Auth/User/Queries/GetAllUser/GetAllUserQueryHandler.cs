using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Auth;
using ClashRoyaleClanWarsAPI.Domain.Shared;

namespace ClashRoyaleClanWarsAPI.Application.Auth.User.Queries.GetAllUser;

internal class GetAllUserQueryHandler : IQueryHandler<GetAllUserQuery, IEnumerable<UserModel>>
{
    private readonly IUserRepository _repository;

    public GetAllUserQueryHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<IEnumerable<UserModel>>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
    {
        var users = await _repository.GetAllAsync();

        return Result.Create(users);
    }
}
