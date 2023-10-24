namespace ClashRoyaleClanWarsAnalytics;

public class UserDeckRequest
{
    public List<string> Cards { get; set; }
}

public class PresetDeck
{
    public string Name { get; set; }
    public List<string> Cards { get; set; }
}
