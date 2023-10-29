using ClashRoyaleClanWarsAPI.Application.Common.Queries.GetModelById;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;
using ClashRoyaleClanWarsAPI.Domain.Models.Card;

namespace ClashRoyaleClanWarsAPI.Application.Models.Card.Queries;

public class GetCardByIdQueryHandler : GetModelByIdQueryHandler<CardModel, int>
{
    public GetCardByIdQueryHandler(ICardRepository repository) : base(repository)
    {
    }
}
