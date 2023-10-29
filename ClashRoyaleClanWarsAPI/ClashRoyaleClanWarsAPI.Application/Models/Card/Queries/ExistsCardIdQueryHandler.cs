using ClashRoyaleClanWarsAPI.Application.Common.Queries.ExistsModelId;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;
using ClashRoyaleClanWarsAPI.Domain.Models.Card;

namespace ClashRoyaleClanWarsAPI.Application.Models.Card.Queries;

public class ExistsCardIdQueryHandler : ExistsModelIdQueryHandler<CardModel, int>
{
    public ExistsCardIdQueryHandler(ICardRepository repository) : base(repository)
    {
    }
}
