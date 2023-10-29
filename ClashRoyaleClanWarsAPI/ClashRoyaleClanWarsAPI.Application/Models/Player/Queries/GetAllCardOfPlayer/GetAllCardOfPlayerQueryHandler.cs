using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;
using ClashRoyaleClanWarsAPI.Domain.Errors;
using ClashRoyaleClanWarsAPI.Domain.Exceptions;
using ClashRoyaleClanWarsAPI.Domain.Models.Card;
using ClashRoyaleClanWarsAPI.Domain.Shared;

namespace ClashRoyaleClanWarsAPI.Application.Models.Player.Queries.GetAllCardOfPlayer;

public class GetAllCardOfPlayerQueryHandler : IQueryHandler<GetAllCardOfPlayerQuery, IEnumerable<CardModel>>
{
    private readonly IPlayerRepository _repository;

    public GetAllCardOfPlayerQueryHandler(IPlayerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<IEnumerable<CardModel>>> Handle(GetAllCardOfPlayerQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<CardModel> cards;

        try
        {
            cards = await _repository.GetAllCardsOfPlayerAsync(request.Id);
        }
        catch (IdNotFoundException<int> e)
        {
            return Result.Failure<IEnumerable<CardModel>>(ErrorTypes.Models.IdNotFound(e.Message));
        }

        return Result.Create(cards);
    }
}
