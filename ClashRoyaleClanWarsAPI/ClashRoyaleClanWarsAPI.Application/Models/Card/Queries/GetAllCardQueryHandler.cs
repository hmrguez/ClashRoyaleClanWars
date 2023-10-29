using ClashRoyaleClanWarsAPI.Application.Common.Queries.GetAllModel;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;
using ClashRoyaleClanWarsAPI.Domain.Models.Card;

namespace ClashRoyaleClanWarsAPI.Application.Models.Card.Queries;

public class GetAllCardQueryHandler : GetAllModelQueryHandler<CardModel, int>
{
    public GetAllCardQueryHandler(ICardRepository repository) : base(repository)
    {
    }
}
