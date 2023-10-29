using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;
using ClashRoyaleClanWarsAPI.Domain.Models;

namespace ClashRoyaleClanWarsAPI.Application.Models.Clan.Queries.GetClanByIdFullLoad;

public record GetClanByIdFullLoadQuery(int Id, bool FullLoad) : IQuery<ClanModel>;
