using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;
    
namespace ClashRoyaleClanWarsAPI.Application.Models.Player.Commands.AddDonation;

public record AddDonationCommand(int PlayerId, int ClanId, int CardId, int Amount) : ICommand;
