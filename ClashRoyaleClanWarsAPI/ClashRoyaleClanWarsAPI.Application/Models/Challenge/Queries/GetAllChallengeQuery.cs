using ClashRoyaleClanWarsAPI.Application.Common.Queries.GetAllModel;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;
using ClashRoyaleClanWarsAPI.Domain.Models;

namespace ClashRoyaleClanWarsAPI.Application.Models.Challenge.Queries;

internal class GetAllChallengeQuery : GetAllModelQueryHandler<ChallengeModel, int>
{
    public GetAllChallengeQuery(IChallengeRepository repository) : base(repository)
    {
    }
}
