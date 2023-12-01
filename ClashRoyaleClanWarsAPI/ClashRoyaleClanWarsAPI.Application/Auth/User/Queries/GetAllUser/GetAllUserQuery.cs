using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;
using ClashRoyaleClanWarsAPI.Application.Auth.Response;

namespace ClashRoyaleClanWarsAPI.Application.Auth.User.Queries.GetAllUser;

public record GetAllUserQuery() : IQuery<IEnumerable<UserResponse>>;
