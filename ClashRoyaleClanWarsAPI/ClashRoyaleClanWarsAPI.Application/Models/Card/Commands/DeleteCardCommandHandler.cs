using ClashRoyaleClanWarsAPI.Application.Common.Commands.DeleteModel;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;
using ClashRoyaleClanWarsAPI.Domain.Models.Card;

namespace ClashRoyaleClanWarsAPI.Application.Models.Card.Commands;

public class DeleteCardCommandHandler : DeleteModelCommandHandler<CardModel, int>
{
    public DeleteCardCommandHandler(ICardRepository repository) : base(repository)
    {
    }
}
