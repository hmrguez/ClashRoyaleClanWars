using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;

namespace ClashRoyaleClanWarsAPI.Application.Auth.User.Commands.UpdateRole;

public record UpdateRoleCommand(Guid Id, string Role) : ICommand;
