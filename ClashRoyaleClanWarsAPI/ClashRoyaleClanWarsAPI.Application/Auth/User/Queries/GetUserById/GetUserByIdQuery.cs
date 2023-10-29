using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;
using ClashRoyaleClanWarsAPI.Application.Auth.Response;

namespace ClashRoyaleClanWarsAPI.Application.Auth.User.Queries.GetUserById;

public record GetUserByIdQuery(string Id) : IQuery<UserResponse>;
