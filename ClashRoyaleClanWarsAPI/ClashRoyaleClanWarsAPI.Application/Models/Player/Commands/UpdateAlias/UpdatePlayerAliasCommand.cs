using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;

namespace ClashRoyaleClanWarsAPI.Application.Models.Player.Commands.UpdateAlias;

public record UpdatePlayerAliasCommand(int Id, string Alias) : ICommand;
