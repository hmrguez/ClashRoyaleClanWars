using ClashRoyaleClanWarsAPI.Application.Common.Commands.AddModel;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;
using ClashRoyaleClanWarsAPI.Domain.Models;

namespace ClashRoyaleClanWarsAPI.Application.Models.Challenge.Commands;

public class AddChallengeCommandHandler : AddModelCommandHandler<ChallengeModel, int>
{
    public AddChallengeCommandHandler(IChallengeRepository repository) : base(repository)
    {
    }
}
