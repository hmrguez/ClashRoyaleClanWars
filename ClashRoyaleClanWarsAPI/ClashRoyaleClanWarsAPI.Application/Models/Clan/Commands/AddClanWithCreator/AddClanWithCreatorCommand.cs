using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;
using ClashRoyaleClanWarsAPI.Domain.Models;

namespace ClashRoyaleClanWarsAPI.Application.Models.Clan.Commands.AddClanWithCreator;

public record AddClanWithCreatorCommand(int PlayerId, ClanModel Clan) : ICommand<int>;
