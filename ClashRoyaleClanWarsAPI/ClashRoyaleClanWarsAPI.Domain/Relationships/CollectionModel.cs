using ClashRoyaleClanWarsAPI.Domain.Models;
using ClashRoyaleClanWarsAPI.Domain.Models.Card;

namespace ClashRoyaleClanWarsAPI.Domain.Relationships;

public class CollectionModel
{
    private CollectionModel() { }
    public PlayerModel? Player { get; private set; }
    public CardModel? Card { get; private set; }
    public int Level { get; private set; }
    public DateTime Date { get; private set; }

    public static CollectionModel Create(PlayerModel player, CardModel card, int Level, DateTime date)
    {
        var collection = new CollectionModel()
        {
            Player = player,
            Card = card,
            Level = Level,
            Date = date
        };

        return collection;
    }
}
