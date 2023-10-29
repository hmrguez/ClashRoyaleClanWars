using ClashRoyaleClanWarsAPI.Application.Common.Commands.UpdateModel;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;
using ClashRoyaleClanWarsAPI.Domain.Models;

namespace ClashRoyaleClanWarsAPI.Application.Models.Challenge.Commands;

internal class UpdateChallengeCommandHandler : UpdateModelCommandHandler<ChallengeModel, int>
{
    public UpdateChallengeCommandHandler(IChallengeRepository repository) : base(repository)
    {
    }
}
