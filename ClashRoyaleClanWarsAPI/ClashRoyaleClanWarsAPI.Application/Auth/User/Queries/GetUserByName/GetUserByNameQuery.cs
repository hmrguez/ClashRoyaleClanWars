using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;
using ClashRoyaleClanWarsAPI.Application.Auth.Response;

namespace ClashRoyaleClanWarsAPI.Application.Auth.User.Queries.GetUserByName;

public record GetUserByNameQuery(string Name) : IQuery<UserResponse>;
