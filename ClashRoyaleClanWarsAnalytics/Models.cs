namespace ClashRoyaleClanWarsAnalytics;

public record UserDeckRequest(List<string> Cards);

public record DeckScore(string Name, int Score);

public class PresetDeck
{

    public PresetDeck()
    {
        
    }
    
    public PresetDeck(string name, List<string> cards)
    {
        Name = name;
        Cards = cards;
    }

    public string Name { get; set; }
    public List<string> Cards { get; set; }
}
