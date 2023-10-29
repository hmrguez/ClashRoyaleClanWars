using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;

namespace ClashRoyaleClanWarsAPI.Application.Models.Clan.Commands.RemovePlayerClan;

public record RemovePlayerClanCommand(int ClanId, int PlayerId) : ICommand;
