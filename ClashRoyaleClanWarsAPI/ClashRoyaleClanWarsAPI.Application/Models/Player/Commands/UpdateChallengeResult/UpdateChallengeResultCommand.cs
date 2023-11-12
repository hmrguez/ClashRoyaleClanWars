using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;

namespace ClashRoyaleClanWarsAPI.Application.Models.Player.Commands.UpdateChallengeResult;

public record UpdateChallengeResultCommand(int PlayerId, int ChallengeId, int Reward) : ICommand;
