using AutoMapper;
using AutoMapper.QueryableExtensions;
using ClashRoyaleClanWarsAPI.Application.Interfaces.Repositories;
using ClashRoyaleClanWarsAPI.Domain.Enum;
using ClashRoyaleClanWarsAPI.Domain.Exceptions;
using ClashRoyaleClanWarsAPI.Domain.Exceptions.Models;
using ClashRoyaleClanWarsAPI.Domain.Models;
using ClashRoyaleClanWarsAPI.Domain.Relationships;
using ClashRoyaleClanWarsAPI.Infrastructure.Persistance;
using ClashRoyaleClanWarsAPI.Infrastructure.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace ClashRoyaleClanWarsAPI.Infrastructure.Repositories.Models;

internal class ClanRepository : BaseRepository<ClanModel, int>, IClanRepository
{
    private readonly IPlayerRepository _playerRepository;
    private readonly IMapper _mapper;

    public ClanRepository(ClashRoyaleDbContext context, IPlayerRepository playerRepository, IMapper mapper) : base(context)
    {
        _playerRepository = playerRepository;
        _mapper = mapper;
    }

    public async Task<ClanModel> GetSingleByIdAsync(int id, bool fullLoad = false)
    {
        var clan = fullLoad ? await _context.Clans
                                            .Include(c => c.Players)!
                                            .ThenInclude(p => p.Player)
                                            .ProjectTo<ClanModel>(_mapper.ConfigurationProvider)
                                            .Where(c => c.Id == id)
                                            .FirstOrDefaultAsync()
                                            ?? throw new IdNotFoundException<int>(id)
                                        :
                                         await base.GetSingleByIdAsync(id);


        return clan;
    }

    public async Task<int> Add(int playerId, ClanModel clan)
    {
        if (_context.ClanPlayers.Where(cp => cp.Player!.Id == playerId).Any())
            throw new PlayerHasClanException();

        await Add(clan);

        var player = await _playerRepository.GetSingleByIdAsync(playerId);

        clan.AddPlayer(player!, RankClan.Leader);

        await Save();

        return clan.Id;
    }

    public async Task<IEnumerable<ClanModel>> GetAllAvailable(int trophies)
    {
        return (await GetAllAsync()).Where(c => c.TypeOpen && c.MinTrophies < trophies);
    }

    public async Task<IEnumerable<ClanModel>> GetAllByName(string name)
    {
        return (await GetAllAsync()).Where(x => x.Name!.Contains(name));
    }

    public async Task AddPlayer(int clanId, int playerId, RankClan rank = RankClan.Member)
    {
        if (await ExistsClanPlayer(playerId, clanId))
            throw new DuplicationIdException(playerId, clanId);

        if( await PlayerHasClan(playerId))
            throw new PlayerHasClanException();

        var clan = await GetSingleByIdAsync(clanId);

        var player = await _playerRepository.GetSingleByIdAsync(playerId);

        if (player.Elo < clan.MinTrophies)
            throw new PlayerHasNoEnoughTrophiesException(player.Elo, clan.MinTrophies);

        clan!.AddPlayer(player!, rank);

        await Save();
    }

    public async Task RemovePlayer(int clanId, int playerId)
    {
        ClanPlayersModel? playerClan = await _context.ClanPlayers
                                    .Include(pc => pc.Clan)
                                    .Include(pc => pc.Player)
                                    .Where(pc => pc.Player!.Id == playerId && pc.Clan!.Id == clanId)
                                    .FirstOrDefaultAsync()
                                    ?? throw new IdNotFoundException<int>(playerId, clanId);


        _context.ClanPlayers.Remove(playerClan!);

        await _context.SaveChangesAsync();
    }

    public async Task UpdatePlayerRank(int clanId, int playerId, RankClan rank)
    {
        var playerClan = await _context.ClanPlayers.FindAsync(playerId, clanId)
            ?? throw new IdNotFoundException<int>(playerId, clanId);

        playerClan.UpdateRank(rank);

        _context.Entry(playerClan).State = EntityState.Modified;

        await Save();
    }

    public async Task<IEnumerable<ClanPlayersModel>> GetPlayers(int clanId)
    {
        var clan = await GetSingleByIdAsync(clanId, true);

        return clan!.Players!.ToList();
    }

    public async Task<bool> ExistsClanPlayer(int playerId, int clandId)
    {
        return await _context.ClanPlayers.FindAsync(playerId, clandId) is not null;
    }

    public override async Task Update(ClanModel model)
    {
        _context.Attach(model);

        _context.Entry(model).Property(x=> x.Name).IsModified = true;
        _context.Entry(model).Property(x=> x.Description).IsModified = true;
        _context.Entry(model).Property(x=> x.MinTrophies).IsModified = true;
        _context.Entry(model).Property(x=> x.Region).IsModified = true;
        _context.Entry(model).Property(x=> x.TypeOpen).IsModified = true;
        _context.Entry(model).Property(x=> x.TrophiesInWar).IsModified = true;

        await Save();
    }
    private async Task<bool> PlayerHasClan(int playerId) =>
        await _context.ClanPlayers
        .AsQueryable()
        .Where(cp => cp.Player!.Id == playerId).FirstOrDefaultAsync() is not null;

}
