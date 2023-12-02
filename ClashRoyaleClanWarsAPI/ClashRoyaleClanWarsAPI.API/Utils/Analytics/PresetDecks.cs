namespace ClashRoyaleClanWarsAPI.API.Utils.Analytics;

public static class PresetDecks
{
    public static List<PresetDeck> GetDecks()
    {
        return new List<PresetDeck>
        {
            new("Giant Double Prince",
                new List<string>
                    { "Giant", "Prince", "Dark Prince", "Musketeer", "FireBall", "Zap", "Skeletons", "Bats" }),
            new("Golem Beatdown",
                new List<string>
                {
                    "Golem", "Night Witch", "Baby Dragon", "Mega Minion", "Tornado", "Poison", "Lumberjack", "Skeletons"
                }),
            new("X-Bow 2.9",
                new List<string>
                    { "X-Bow", "Tesla", "Ice Golem", "Skeletons", "Ice Spirit", "FireBall", "The Log", "Archers" }),
            new("Graveyard Poison",
                new List<string>
                    { "Graveyard", "Poison", "Baby Dragon", "Knight", "Tornado", "Skeletons", "Ice Wizard", "The Log" }),
            new("Mega Knight Miner",
                new List<string>
                    { "Mega Knight", "Miner", "Bats", "Skeletons", "Poison", "The Log", "Mega Minion", "Ice Spirit" }),
            new("Royal Giant",
                new List<string>
                    { "Royal Giant", "Furnace", "Mega Minion", "Minions", "FireBall", "Zap", "Goblin Cage", "Guards" }),
            new("Hog 2.6",
                new List<string>
                    { "Hog Rider", "Ice Golem", "Ice Spirit", "Skeletons", "FireBall", "The Log", "Musketeer", "Cannon" }),
            new("Lava Hound",
                new List<string>
                    { "Lava Hound", "Ballon", "Mega Minion", "Minions", "Tombstone", "FireBall", "Zap", "Skeletons" }),
            new("Giant Skeleton",
                new List<string>
                {
                    "Giant Skeleton", "Ballon", "Bats", "Skeletons", "FireBall", "Zap", "Mega Minion", "Tombstone"
                }),
        };
    }
}
