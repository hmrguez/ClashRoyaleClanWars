using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;

namespace ClashRoyaleClanWarsAPI.Application.Auth.User.Commands.DeleteUser;

public record DeleteUserCommand(string Id) : ICommand;
