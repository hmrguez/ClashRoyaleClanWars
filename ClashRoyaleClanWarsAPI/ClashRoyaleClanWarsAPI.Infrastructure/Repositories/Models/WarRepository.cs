using ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;
using ClashRoyaleClanWarsAPI.Domain.Exceptions;
using ClashRoyaleClanWarsAPI.Domain.Models;
using ClashRoyaleClanWarsAPI.Domain.Relationships;
using ClashRoyaleClanWarsAPI.Infrastructure.Persistance;
using ClashRoyaleClanWarsAPI.Infrastructure.Repositories.Common;

namespace ClashRoyaleClanWarsAPI.Infrastructure.Repositories.Models;

internal class WarRepository : BaseRepository<WarModel, int>, IWarRepository
{
    private readonly IClanRepository _clanRepository;
    public WarRepository(ClashRoyaleDbContext context, IClanRepository clanRepository) : base(context)
    {
        _clanRepository = clanRepository;
    }

    public async Task<IEnumerable<WarModel>> GetWarsByDate(DateTime date)
    {
        return (await GetAllAsync()).Where(w => w.StartDate > date);
    }

    public async Task AddClanToWar(int warId, int clanId, int prize)
    {
        if (await ExistsClanWar(clanId, warId))
            throw new DuplicationIdException(clanId, warId);

        var war = await GetSingleByIdAsync(warId);
        var clan = await _clanRepository.GetSingleByIdAsync(clanId);

        var clanWar = ClanWarsModel.Create(clan, war, prize);

        await _context.ClanWars.AddAsync(clanWar);

        await Save();
    }

    private async Task<bool> ExistsClanWar(int clanId, int warId)
    {
        return await _context.ClanWars.FindAsync(clanId, warId) is not null;
    }
}
