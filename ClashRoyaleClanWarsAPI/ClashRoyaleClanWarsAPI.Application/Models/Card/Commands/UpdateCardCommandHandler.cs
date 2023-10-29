using ClashRoyaleClanWarsAPI.Application.Common.Commands.UpdateModel;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;
using ClashRoyaleClanWarsAPI.Domain.Models.Card;

namespace ClashRoyaleClanWarsAPI.Application.Models.Card.Commands;

public class UpdateCardCommandHandler : UpdateModelCommandHandler<CardModel, int>
{
    public UpdateCardCommandHandler(ICardRepository repository) : base(repository)
    {
    }
}
