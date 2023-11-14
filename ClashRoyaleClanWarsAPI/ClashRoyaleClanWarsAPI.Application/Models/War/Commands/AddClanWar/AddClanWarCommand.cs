using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;

namespace ClashRoyaleClanWarsAPI.Application.Models.War.Commands.AddClanWar;

public record AddClanWarCommand(int ClanId, int WarId, int Prize) : ICommand;
