using ClashRoyaleClanWarsAPI.Domain.Models;

namespace ClashRoyaleClanWarsAPI.Domain.Relationships;

public class ChallengePlayersModel
{
    private ChallengePlayersModel() { }
    public PlayerModel? Player { get; private set; }
    public ChallengeModel? Challenge { get; private set; }
    public int PrizeAmount { get; private set; }

    public static ChallengePlayersModel Create(PlayerModel player, ChallengeModel challenge, int prizeAmount)
    {
        return new ChallengePlayersModel
        {
            Player = player,
            Challenge = challenge,
            PrizeAmount = prizeAmount
        };
    }
}
