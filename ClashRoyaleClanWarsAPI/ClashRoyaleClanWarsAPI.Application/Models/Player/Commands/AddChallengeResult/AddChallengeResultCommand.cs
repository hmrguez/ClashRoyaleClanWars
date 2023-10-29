using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;

namespace ClashRoyaleClanWarsAPI.Application.Models.Player.Commands.AddChallengeResult;

public record AddChallengeResultCommand(int PlayerId, int ChallengeId, int Reward) : ICommand;
