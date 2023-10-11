using AutoMapper;
using AutoMapper.QueryableExtensions;
using ClashRoyaleClanWarsAPI.Data;
using ClashRoyaleClanWarsAPI.Dtos.ClanDto;
using ClashRoyaleClanWarsAPI.Exceptions;
using ClashRoyaleClanWarsAPI.Interfaces.ServicesInterfaces;
using ClashRoyaleClanWarsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClashRoyaleClanWarsAPI.Services
{
    public class ClanService : BaseService<ClanModel, int>, IClanService
    {
        private readonly IPlayerService _playerService;
        private readonly IMapper _mapper;

        public ClanService(DataContext context, IPlayerService playerService, IMapper mapper) : base(context)
        {
            _playerService = playerService;
            _mapper = mapper;
        }

        public async Task<int> Add(int playerId, ClanModel clan)
        {
            await Add(clan);

            var player = await _playerService.GetSingleByIdAsync(playerId);

            var playerClan = CreatePlayerClan(player, clan, RankClan.Leader);

            await _context.PlayerClans.AddAsync(playerClan);
            await Save();

            return clan.Id;
        }

        public async Task AddPlayer(int clanId, int playerId, RankClan rank = RankClan.Member)
        {
            ClanModel clan = await GetSingleByIdAsync(clanId);
            PlayerModel player = await _playerService.GetSingleByIdAsync(playerId);

            var playerClan = CreatePlayerClan(player, clan, rank);

            clan.Players ??= new List<PlayerClansModel>();

            await _context.PlayerClans.AddAsync(playerClan);

            await Save();
        }

        public async Task<IEnumerable<ClanModel>> GetAllAvailableClans(int trophies)
        {
            if (_context.Clans == null) throw new ModelNotFoundException<ClanModel>();

            return (await GetAllByTrophies(trophies)).Where(c=> c.TypeOpen);
        }

        public async Task<IEnumerable<ClanModel>> GetAllByName(string name)
        {
            if (_context.Clans == null) throw new ModelNotFoundException<ClanModel>();

            return (await GetAllAsync()).Where(x => x.Name!.Contains(name));
        }

        public async Task<IEnumerable<ClanModel>> GetAllByTrophies(int trophies)
        {
            if (_context.Clans == null) throw new ModelNotFoundException<ClanModel>();

            return (await GetAllAsync()).Where(c=> c.MinTrophies < trophies);
        }

        public async Task RemovePlayer(int clanId, int playerId)
        {
            PlayerClansModel? playerClan = await _context.PlayerClans
                                        .Include(pc=>pc.Clan)
                                        .Include(pc=> pc.Player)
                                        .Where(pc=> (pc.Player!.Id == playerId) && (pc.Clan!.Id == clanId))
                                        .FirstOrDefaultAsync()
                                        ?? throw new IdNotFoundException<PlayerClansModel, int>();
            

            _context.PlayerClans.Remove(playerClan!);
            await _context.SaveChangesAsync();
        }

        public PlayerClansModel CreatePlayerClan(PlayerModel player, ClanModel clan, RankClan rank)
        {
            var playerClan = new PlayerClansModel()
            {
                Player = player,
                Clan = clan,
                Rank = rank
            };

            return playerClan;
        }

        public async Task UpdatePlayerRank(int clanId, int playerId, RankClan rank)
        {
            var playerClan = await _context.PlayerClans.FindAsync(playerId, clanId)
                 ?? throw new IdNotFoundException<PlayerClansModel, int>();

            playerClan.Rank = rank;

            _context.Entry(playerClan).State = EntityState.Modified;

            await Save();
        }

        public override async Task Delete(int id)
        {
            if (_context.Clans == null) throw new ModelNotFoundException<ClanModel>();

            ClanModel clan = await GetSingleByIdAsync(id, true);

            clan.Players!.Clear();

            _context.Clans.Remove(clan);

            await Save();
        }
        
        public async Task<IEnumerable<PlayerClansModel>> GetPlayers(int clanId)
        {
            var clan = await GetSingleByIdAsync(clanId, true);

            return clan.Players!.ToList();
        }

        public async Task<ClanModel> GetSingleByIdAsync(int id, bool fullLoad=false)
        {
            if (_context.Clans == null) throw new ModelNotFoundException<ClanModel>();

            ClanModel? clan = fullLoad ? _context.Clans?
                                                .Include(c => c.Players)!
                                                .ThenInclude(p=> p.Player)
                                                .ProjectTo<ClanModel>(_mapper.ConfigurationProvider)
                                                .Where(c => c.Id == id)
                                                .First()
                                            :
                                             await base.GetSingleByIdAsync(id);


            return clan ?? throw new IdNotFoundException<ClanModel, int>(id);
        }
    }
}
