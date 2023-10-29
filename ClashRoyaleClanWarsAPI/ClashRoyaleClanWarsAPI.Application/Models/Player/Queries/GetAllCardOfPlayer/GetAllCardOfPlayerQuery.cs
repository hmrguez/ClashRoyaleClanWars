using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;
using ClashRoyaleClanWarsAPI.Domain.Models.Card;

namespace ClashRoyaleClanWarsAPI.Application.Models.Player.Queries.GetAllCardOfPlayer;

public record GetAllCardOfPlayerQuery(int Id) : IQuery<IEnumerable<CardModel>>;
