using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;
using ClashRoyaleClanWarsAPI.Application.Auth.Response;

namespace ClashRoyaleClanWarsAPI.Application.Auth.Account.Queries.LoginUser;

public record LoginUserQuery(LoginModel LoginModel) : IQuery<LoginResponse>;
