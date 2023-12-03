using ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;
using ClashRoyaleClanWarsAPI.Domain.Models;
using ClashRoyaleClanWarsAPI.Infrastructure.Persistance;
using ClashRoyaleClanWarsAPI.Infrastructure.Repositories.Common;

namespace ClashRoyaleClanWarsAPI.Infrastructure.Repositories.Models;

internal class ChallengeRepository : BaseRepository<ChallengeModel, int>, IChallengeRepository
{
    public ChallengeRepository(ClashRoyaleDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<ChallengeModel>> GetAllOpenChallenges()
        => (await GetAllAsync()).Where(x => x.IsOpen).ToList();
}
