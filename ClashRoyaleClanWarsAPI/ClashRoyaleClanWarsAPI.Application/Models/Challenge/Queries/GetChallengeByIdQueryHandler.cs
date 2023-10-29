using ClashRoyaleClanWarsAPI.Application.Common.Queries.GetModelById;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;
using ClashRoyaleClanWarsAPI.Domain.Models;

namespace ClashRoyaleClanWarsAPI.Application.Models.Challenge.Queries;

internal class GetChallengeByIdQueryHandler : GetModelByIdQueryHandler<ChallengeModel, int>
{
    public GetChallengeByIdQueryHandler(IChallengeRepository repository) : base(repository)
    {
    }
}
