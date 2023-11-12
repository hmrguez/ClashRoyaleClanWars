using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;

namespace ClashRoyaleClanWarsAPI.Application.Models.Player.Commands.AddChallengePlayer;

public record AddChallengePlayerCommand(int PlayerId, int ChallengeId, int Reward) : ICommand;
