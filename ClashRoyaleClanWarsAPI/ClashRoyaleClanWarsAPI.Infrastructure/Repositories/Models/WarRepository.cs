using AutoMapper;
using AutoMapper.QueryableExtensions;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;
using ClashRoyaleClanWarsAPI.Domain.Exceptions;
using ClashRoyaleClanWarsAPI.Domain.Exceptions.Models;
using ClashRoyaleClanWarsAPI.Domain.Models;
using ClashRoyaleClanWarsAPI.Domain.Relationships;
using ClashRoyaleClanWarsAPI.Infrastructure.Persistance;
using ClashRoyaleClanWarsAPI.Infrastructure.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace ClashRoyaleClanWarsAPI.Infrastructure.Repositories.Models;

internal class WarRepository : BaseRepository<WarModel, int>, IWarRepository
{
    private readonly IMapper _mapper;
    private readonly IClanRepository _clanRepository;
    public WarRepository(ClashRoyaleDbContext context, IClanRepository clanRepository, IMapper mapper) : base(context)
    {
        _clanRepository = clanRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<WarModel>> GetWarsByDate(DateTime date)
    {
        return (await GetAllAsync()).Where(w => w.StartDate > date);
    }

    public override async Task<WarModel> GetSingleByIdAsync(int id)
    {
        return await _context.Wars
            .Include(w => w.ClansInWar)
            .ThenInclude(c => c.Clan)
            .ProjectTo<WarModel>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync(w => w.Id == id)
            ?? throw new IdNotFoundException<int>(id);

    }
    public async Task AddClanToWar(int warId, int clanId, int prize)
    {
        if (await ExistsClanInWar(clanId, warId))
            throw new DuplicationIdException(clanId, warId);

        if (await ExistsClanInWar(clanId))
            throw new ClanAlreadyInWarException(clanId);

        var war = await GetSingleByIdAsync(warId);
        var clan = await _clanRepository.GetSingleByIdAsync(clanId);

        var clanWar = ClanWarsModel.Create(clan.Id, war.Id, prize);

        await _context.ClanWars.AddAsync(clanWar);

        await Save();
    }

    private async Task<bool> ExistsClanInWar(int clanId, int warId)
    {
        return await _context.ClanWars.FindAsync(clanId, warId) is not null;
    }
    private async Task<bool> ExistsClanInWar(int clanId)
    {
        return await _context.ClanWars.Where(w => w.Clan!.Id == clanId).FirstOrDefaultAsync() is not null;
    }
}
