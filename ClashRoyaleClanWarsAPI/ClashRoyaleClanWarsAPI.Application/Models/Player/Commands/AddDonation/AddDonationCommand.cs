using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;
    
namespace ClashRoyaleClanWarsAPI.Application.Models.Player.Commands.AddDonation;

public record AddDonationCommand(int PlayerId, int CardId, int Amount, DateTime Date) : ICommand;
