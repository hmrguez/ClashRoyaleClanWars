using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;

namespace ClashRoyaleClanWarsAPI.Application.Models.Clan.Commands.AddPlayerClan;

public record AddPlayerClanCommand(int ClanId, int PlayerId) : ICommand;
