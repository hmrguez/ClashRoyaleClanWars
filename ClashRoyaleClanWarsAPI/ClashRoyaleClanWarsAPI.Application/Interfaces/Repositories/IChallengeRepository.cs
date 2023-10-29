using ClashRoyaleClanWarsAPI.Domain.Models;

namespace ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;

public interface IChallengeRepository : IBaseRepository<ChallengeModel, int>
{
    Task<IEnumerable<ChallengeModel>> GetAllOpenChallenges();
}
