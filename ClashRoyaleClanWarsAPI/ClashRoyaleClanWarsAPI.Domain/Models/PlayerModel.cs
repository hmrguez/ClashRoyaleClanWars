using ClashRoyaleClanWarsAPI.Domain.Common.Interfaces;
using ClashRoyaleClanWarsAPI.Domain.Models.Card;
using ClashRoyaleClanWarsAPI.Domain.Relationships;

namespace ClashRoyaleClanWarsAPI.Domain.Models;

public class PlayerModel : IEntity<int>
{
    private PlayerModel(string alias)
    {
        Alias = alias;
    }
    public int Id { get; private set; }
    public string? Alias { get; private set; }
    public int Elo { get; private set; }
    public int Level { get; private set; }
    public int Victories { get; private set; }
    public int CardAmount { get; private set; }
    public int MaxElo { get; private set; }
    public UserModel User { get; private set; }
    public CardModel? FavoriteCard { get; private set; }
    public List<CollectionModel>? Cards { get; private set; }

    public void AddCard(CardModel card)
    {
        Cards ??= new List<CollectionModel>();

        var collect = CollectionModel.Create(this, card, card.InitialLevel, DateTime.UtcNow);

        Cards!.Add(collect);
    }

    public void AddFavoriteCard(CardModel card) => FavoriteCard ??= card;

    public bool HaveCard(int cardId)
    {
        Cards ??= new List<CollectionModel>();
        return Cards.Any(c => c.Card is not null && c.Card.Id == cardId);
    }

    public void ChangeAlias(string alias) => Alias = alias;

    public void AddCardAmount() => CardAmount += 1;

    private void UpdateMaxElo(int maxElo) => MaxElo = maxElo;

    public void AddVictory() => Victories += 1;

    public void UpdateElo(int elo)
    {
        if (MaxElo < Elo)
        {
            MaxElo = Elo;
            return;
        }

        Elo += elo;

        if (Elo > MaxElo)
            UpdateMaxElo(Elo);
    }

    public static PlayerModel Create(string alias)
    {
        return new PlayerModel(alias);
    }
}
