using ClashRoyaleClanWarsAPI.Data;
using ClashRoyaleClanWarsAPI.Dtos.ClanDto;
using ClashRoyaleClanWarsAPI.Exceptions;
using ClashRoyaleClanWarsAPI.Interfaces.ServicesInterfaces;
using ClashRoyaleClanWarsAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClashRoyaleClanWarsAPI.Services
{
    public class ClanService : BaseService<ClanModel>, IClanService
    {
        private readonly IPlayerService _playerService;

        public ClanService(DataContext context, IPlayerService playerService) : base(context)
        {
            _playerService = playerService;
        }

        public async Task<int> Add(int playerId, ClanModel clan)
        {
            var player = await _playerService.GetSingleByIdAsync(playerId);

            await base.Add(clan);

            var playerClan = new PlayerClansModel()
            {
                Player = player,
                Clan = clan,
                Rank = RankClan.Leader
            };

            _context.PlayerClans.Add(playerClan);

            await Save();
            return clan.Id;
        }
        
        public async Task<IEnumerable<ClanModel>> GetAllAvailableClans(int trophies)
        {
            if (_context.Clans == null) throw new ModelNotFoundException<ClanModel>();

            return (await GetAllByTrophies(trophies)).Where(c=> c.TypeOpen);
        }

        public async Task<IEnumerable<ClanModel>> GetAllByName(string name)
        {
            if (_context.Clans == null) throw new ModelNotFoundException<ClanModel>();

            return (await GetAllAsync()).Where(x => x.Name.Contains(name));
        }

        public async Task<IEnumerable<ClanModel>> GetAllByTrophies(int trophies)
        {
            if (_context.Clans == null) throw new ModelNotFoundException<ClanModel>();

            return (await GetAllAsync()).Where(c=> c.MinTrophies < trophies);
        }
    }
}
