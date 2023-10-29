using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;
using ClashRoyaleClanWarsAPI.Domain.Models;

namespace ClashRoyaleClanWarsAPI.Application.Models.Player.Queries.GetPlayerByIdFullLoad;

public record GetPlayerByIdFullLoadQuery(int Id, bool FullLoad) : IQuery<PlayerModel>;
