using ClashRoyaleClanWarsAnalytics;

var builder = WebApplication.CreateBuilder(args);

var cardScores = CardScore.GetCardScores();
var presetDecks = PresetDecks.GetDecks();

// Initialize cardScores and presetDecks here...

builder.Services.AddSingleton(cardScores);
builder.Services.AddSingleton(presetDecks);

var app = builder.Build();

app.MapPost("/analysis",
    async (HttpContext context, Dictionary<string, Dictionary<string, int>> cardScores, List<PresetDeck> presetDecks) =>
    {
        
        var request = await context.Request.ReadFromJsonAsync<UserDeckRequest>();
        var scores = new List<(string, int)>();

        foreach (var presetDeck in presetDecks)
        {
            var totalScore = 0;

            foreach (var userCard in request.Cards)
            {
                if (!cardScores.TryGetValue(userCard, out var cardScore)) continue;

                foreach (var presetCard in presetDeck.Cards)
                    if (cardScore.TryGetValue(presetCard, out var score))
                        totalScore += score;
            }

            scores.Add((presetDeck.Name, totalScore));
        }

        var response = scores
            .OrderByDescending(s => s.Item2)
            .Select(x=>new DeckScore(x.Item1, x.Item2))
            .ToList();

        await context.Response.WriteAsJsonAsync(response);
    });

app.Run();