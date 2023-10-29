using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;
using ClashRoyaleClanWarsAPI.Domain.Models;

namespace ClashRoyaleClanWarsAPI.Application.Models.Clan.Commands.AddClan;

public record AddClanCommand(int PlayerId, ClanModel Clan) : ICommand<int>;
