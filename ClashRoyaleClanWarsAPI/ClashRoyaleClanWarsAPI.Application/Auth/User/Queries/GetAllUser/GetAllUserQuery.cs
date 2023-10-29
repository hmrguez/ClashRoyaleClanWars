using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;

namespace ClashRoyaleClanWarsAPI.Application.Auth.User.Queries.GetAllUser;

public record GetAllUserQuery() : IQuery<IEnumerable<UserModel>>;
