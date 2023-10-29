using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;
using ClashRoyaleClanWarsAPI.Domain.Models.Card;
using ClashRoyaleClanWarsAPI.Domain.Shared;

namespace ClashRoyaleClanWarsAPI.Application.Models.Card.Queries.GetCardsByName;

public class GetCardsByNameQueryHandler : IQueryHandler<GetCardsByNameQuery, IEnumerable<CardModel>>
{
    private readonly ICardRepository _repository;
    public GetCardsByNameQueryHandler(ICardRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<IEnumerable<CardModel>>> Handle(GetCardsByNameQuery request, CancellationToken cancellationToken)
    {
        var cards = await _repository.GetCardsByNameAsync(request.Name);

        return Result.Create(cards);
    }
}
