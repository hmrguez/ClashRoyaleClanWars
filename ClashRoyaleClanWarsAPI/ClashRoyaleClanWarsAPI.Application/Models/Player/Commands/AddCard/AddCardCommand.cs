using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;

namespace ClashRoyaleClanWarsAPI.Application.Models.Player.Commands.AddCard;

public record AddCardCommand(int PlayerId, int CardId) : ICommand;
