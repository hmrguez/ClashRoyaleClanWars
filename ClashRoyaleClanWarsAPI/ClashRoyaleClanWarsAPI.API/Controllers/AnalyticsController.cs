using ClashRoyaleClanWarsAPI.API.Utils.Analytics;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClashRoyaleClanWarsAPI.API.Controllers;

[Route("api/analytics")]
public class AnalyticsController : ControllerBase
{

    [HttpPost]
    public IActionResult Analysis(UserDeckRequest request)
    {
        var presetDecks = PresetDecks.GetDecks();
        var cardScores = CardScore.GetCardScores();

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
            .Select(x => new DeckScore(x.Item1, x.Item2))
            .ToList();

        return Ok(response);
    }
}

public record UserDeckRequest(List<string> Cards);

public record DeckScore(string Name, int Score);