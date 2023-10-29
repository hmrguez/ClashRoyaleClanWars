using ClashRoyaleClanWarsAPI.Application.Abstractions.CQRS;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;
using ClashRoyaleClanWarsAPI.Domain.Models;
using ClashRoyaleClanWarsAPI.Domain.Shared;

namespace ClashRoyaleClanWarsAPI.Application.Models.Challenge.Queries.GetAllOpen;

public class GetAllOpenChallengeQueryHandler : IQueryHandler<GetAllOpenChallengeQuery, IEnumerable<ChallengeModel>>
{
    private readonly IChallengeRepository _challengeRepository;

    public GetAllOpenChallengeQueryHandler(IChallengeRepository challengeRepository)
    {
        _challengeRepository = challengeRepository;
    }

    public async Task<Result<IEnumerable<ChallengeModel>>> Handle(GetAllOpenChallengeQuery request, CancellationToken cancellationToken)
    {
        var challenges = await _challengeRepository.GetAllOpenChallenges();
        return Result.Create(challenges);
    }
}
