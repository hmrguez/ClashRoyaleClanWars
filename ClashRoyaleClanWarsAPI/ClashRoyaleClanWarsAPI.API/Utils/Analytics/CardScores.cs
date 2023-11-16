namespace ClashRoyaleClanWarsAPI.API.Utils.Analytics;

public static class CardScore
{
    public static Dictionary<string, Dictionary<string, int>> GetCardScores()
    {
        var cardScores = new Dictionary<string, Dictionary<string, int>>();
        
        var knightScores = new Dictionary<string, int>();
        knightScores.Add("Knight", 2);
        knightScores.Add("Archers", 3);
        knightScores.Add("Bomber", 4);
        knightScores.Add("Skeletons", 5);
        knightScores.Add("Minions", 6);
        
        var musketeeerScores = new Dictionary<string, int>();
        musketeeerScores.Add("Knight", 3);
        musketeeerScores.Add("Archers", 2);
        musketeeerScores.Add("Bomber", 3);
        musketeeerScores.Add("Skeletons", 4);
        
        var bomberScores = new Dictionary<string, int>();
        bomberScores.Add("Knight", 4);
        bomberScores.Add("Archers", 3);
        bomberScores.Add("Bomber", 2);
        
        cardScores.Add("Knight", knightScores);
        cardScores.Add("Archers", musketeeerScores);
        cardScores.Add("Bomber", bomberScores);
        
        return cardScores;
    }
}