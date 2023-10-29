using ClashRoyaleClanWarsAPI.Application.Common.Commands.DeleteModel;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;
using ClashRoyaleClanWarsAPI.Domain.Models;

namespace ClashRoyaleClanWarsAPI.Application.Models.Challenge.Commands;

internal class DeleteChallengeCommandHandler : DeleteModelCommandHandler<ChallengeModel, int>
{
    public DeleteChallengeCommandHandler(IChallengeRepository repository) : base(repository)
    {
    }
}
