using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;
using ClashRoyaleClanWarsAPI.Domain.Models;

namespace ClashRoyaleClanWarsAPI.Application.Models.War.Queries.GetUpCommingWars;

public record GetUpComingWarsQuery(DateTime Date) : IQuery<IEnumerable<WarModel>>;
