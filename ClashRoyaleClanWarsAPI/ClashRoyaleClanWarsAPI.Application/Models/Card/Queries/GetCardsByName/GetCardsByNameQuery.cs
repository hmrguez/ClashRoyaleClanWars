using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;
using ClashRoyaleClanWarsAPI.Domain.Models.Card;

namespace ClashRoyaleClanWarsAPI.Application.Models.Card.Queries.GetCardsByName;

public record GetCardsByNameQuery(string Name) : IQuery<IEnumerable<CardModel>>;
