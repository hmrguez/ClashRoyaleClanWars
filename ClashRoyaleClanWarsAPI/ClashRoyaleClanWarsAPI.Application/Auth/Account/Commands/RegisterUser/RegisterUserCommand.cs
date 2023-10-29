using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;
using ClashRoyaleClanWarsAPI.Application.Auth.Utils;

namespace ClashRoyaleClanWarsAPI.Application.Auth.Account.Commands.RegisterUser;

public record RegisterUserCommand(RegisterModel RegisterModel, RoleEnum Role = RoleEnum.User) : ICommand<string>;
