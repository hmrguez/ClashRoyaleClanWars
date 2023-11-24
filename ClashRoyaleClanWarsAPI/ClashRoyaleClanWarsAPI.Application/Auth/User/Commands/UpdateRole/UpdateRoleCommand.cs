using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;

namespace ClashRoyaleClanWarsAPI.Application.Auth.User.Commands.UpdateRole;

public record UpdateRoleCommand(string Id, string Role) : ICommand;
