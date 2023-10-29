using ClashRoyaleClanWarsAPI.Domain.Models.Card;

namespace ClashRoyaleClanWarsAPI.Application.Common.Mapping;

public class CollectionDto
{
    public CardModel? Card { get; set; }
    public int Level { get; set; }
    public DateTime Date { get; set; }
}
