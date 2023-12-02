using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;

namespace ClashRoyaleClanWarsAPI.Application.Auth.User.Commands.ChangePassword
{
    public record ChangePasswordCommand(Guid Id, string Password) : ICommand;
}
