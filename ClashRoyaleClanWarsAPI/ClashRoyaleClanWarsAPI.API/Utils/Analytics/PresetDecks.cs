namespace ClashRoyaleClanWarsAPI.API.Utils.Analytics;

public static class PresetDecks
{
    public static List<PresetDeck> GetDecks()
    {
        return new List<PresetDeck>
        {
            new("Giant Double Prince",
                new List<string>
                    { "Giant", "Prince", "Dark Prince", "Musketeer", "Fireball", "Zap", "Skeletons", "Bats" }),
            new("Golem Beatdown",
                new List<string>
                {
                    "Golem", "Night Witch", "Baby Dragon", "Mega Minion", "Tornado", "Poison", "Lumberjack", "Skeletons"
                }),
            new("X-Bow 2.9",
                new List<string>
                    { "X-Bow", "Tesla", "Ice Golem", "Skeletons", "Ice Spirit", "Fireball", "Log", "Archers" }),
            new("Graveyard Poison",
                new List<string>
                    { "Graveyard", "Poison", "Baby Dragon", "Knight", "Tornado", "Skeletons", "Ice Wizard", "Log" }),
            new("Mega Knight Miner",
                new List<string>
                    { "Mega Knight", "Miner", "Bats", "Skeletons", "Poison", "Log", "Mega Minion", "Ice Spirit" }),
            new("Royal Giant",
                new List<string>
                    { "Royal Giant", "Furnace", "Mega Minion", "Minions", "Fireball", "Zap", "Goblin Cage", "Guards" }),
            new("Hog 2.6",
                new List<string>
                    { "Hog Rider", "Ice Golem", "Ice Spirit", "Skeletons", "Fireball", "Log", "Musketeer", "Cannon" }),
            new("Lava Hound",
                new List<string>
                    { "Lava Hound", "Balloon", "Mega Minion", "Minions", "Tombstone", "Fireball", "Zap", "Skeletons" }),
            new("Giant Skeleton",
                new List<string>
                {
                    "Giant Skeleton", "Balloon", "Bats", "Skeletons", "Fireball", "Zap", "Mega Minion", "Tombstone"
                }),
        };
    }
}
