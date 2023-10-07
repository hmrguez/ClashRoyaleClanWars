using AutoMapper;
using ClashRoyaleClanWarsAPI.Dtos.ClanDto;
using ClashRoyaleClanWarsAPI.Exceptions;
using ClashRoyaleClanWarsAPI.Interfaces.ServicesInterfaces;
using ClashRoyaleClanWarsAPI.Models;
using ClashRoyaleClanWarsAPI.Services;
using ClashRoyaleClanWarsAPI.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClashRoyaleClanWarsAPI.Controllers.ModelControllers
{
    [Route("api/clans")]
    [ApiController]
    public class ClanController : ControllerBase
    {
        private readonly IClanService _clanService;
        private readonly IMapper _mapper;

        public ClanController(IClanService clanService, IMapper mapper) 
        {
            _clanService = clanService;
            _mapper = mapper;
        }
        // GET: api/clans
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<ClanModel>? clans = null;
            try
            {
                clans = await _clanService.GetAllAsync();
            }
            catch (ModelNotFoundException<ClanModel> e)
            {
                return NotFound(new RequestResponse<ClanModel>(message: e.Message, success: false));
            }

            return Ok(new RequestResponse<IEnumerable<ClanModel>>(clans!));
        }

        // GET api/clans/{clanId:int}
        [HttpGet("{clanId:int}")]
        public async Task<IActionResult> Get(int clanId)
        {
            ClanModel? clan = null;

            try
            {
                clan = await _clanService.GetSingleByIdAsync(clanId, true);
            }
            catch (ModelNotFoundException<ClanModel> e)
            {
                return NotFound(new RequestResponse<ClanModel>(message: e.Message, success: false));
            }
            catch (IdNotFoundException<ClanModel, int> e)
            {
                return NotFound(new RequestResponse<ClanModel>(message: e.Message, success: false));
            }

            return Ok(new RequestResponse<ClanModel>(clan!));
        }

        // POST api/clans/{playerId:int}
        [HttpPost("{playerId:int}")]
        public async Task<IActionResult> Post(int playerId, [FromBody] AddClanDto clanDto)
        {
            ClanModel clan;
            try
            {
                clan = _mapper.Map<ClanModel>(clanDto);
                await _clanService.Add(playerId, clan);
            }
            catch (ModelNotFoundException<ClanModel> e)
            {
                return NotFound(new RequestResponse<ClanModel>(message: e.Message, success: false));
            }
            catch (IdNotFoundException<PlayerModel, int> e)
            {
                return NotFound(new RequestResponse<PlayerModel>(message: e.Message, success: false));
            }


            return Created($"api/clans/{clan.Id}", new RequestResponse<ClanModel>(message: "Clan created", success: true));

            
        }

        // PUT api/clans/{clanId:int}
        [HttpPut("{clanId:int}")]
        public async Task<IActionResult> Put(int clanId, [FromBody] UpdateClanDto clanDto)
        {
            if (clanId != clanDto.Id)
                return BadRequest(new RequestResponse<ClanModel>(message: "Ids do not match", success: false));

            try
            {
                await _clanService.Update(_mapper.Map<ClanModel>(clanDto));
            }
            catch (ModelNotFoundException<ClanModel> e)
            {
                return NotFound(new RequestResponse<ClanModel>(message: e.Message, success: false));
            }
            catch (IdNotFoundException<PlayerModel, int> e)
            {
                return NotFound(new RequestResponse<PlayerModel>(message: e.Message, success: false));
            }

            return NoContent();
        }

        // DELETE api/clans/{clanId:int}
        [HttpDelete("{clanId:int}")]
        public async Task<IActionResult> Delete(int clanId)
        {
            try
            {
                await _clanService.Delete(clanId);
            }
            catch (ModelNotFoundException<ClanModel> e)
            {
                return NotFound(new RequestResponse<ClanModel>(message: e.Message, success: false));
            }
            catch (IdNotFoundException<ClanModel, int> e)
            {
                return NotFound(new RequestResponse<ClanModel>(message: e.Message, success: false));
            }

            return NoContent();
        }

        //GET api/clans/availables/{trophies:int}
        [HttpGet("availables/{trophies:int}")]
        public async Task<IActionResult> GetClanAvailables(int trophies)
        {
            IEnumerable<ClanModel>? clansAvailables = null;
            try
            {
                clansAvailables = await _clanService.GetAllAvailableClans(trophies);
            }
            catch (ModelNotFoundException<ClanModel> e)
            {
                return NotFound(new RequestResponse<ClanModel>(message: e.Message, success: false));
            }

            return Ok(new RequestResponse<IEnumerable<ClanModel>>(clansAvailables!));
        }

        //GET api/clans/name/{clanName}
        [HttpGet("name/{clanName}")]
        public async Task<IActionResult> GetClansByName(string clanName)
        {
            IEnumerable<ClanModel>? clansByName = null;
            try
            {
                clansByName = await _clanService.GetAllByName(clanName);
            }
            catch (ModelNotFoundException<ClanModel> e)
            {
                return NotFound(new RequestResponse<ClanModel>(message: e.Message, success: false));
            }

            return Ok(new RequestResponse<IEnumerable<ClanModel>>(clansByName!));
        }

        [HttpGet("{clanId:int}/players")]
        public async Task<IActionResult> GetPlayers(int clanId)
        {
            IEnumerable<PlayerClansModel>? playerClan;
            try
            {
                playerClan = await _clanService.GetPlayers(clanId);

            }
            catch (ModelNotFoundException<ClanModel> e)
            {
                return NotFound(new RequestResponse<ClanModel>(message: e.Message, success: false));
            }
            catch (IdNotFoundException<ClanModel, int> e)
            {
                return NotFound(new RequestResponse<ClanModel>(message: e.Message, success: false));
            }

            return Ok(new RequestResponse<IEnumerable<PlayerClansModel>>(data: playerClan, message: "Ok", success: true));
        }

        [HttpPost("{clanId:int}/players/{playerId}")]
        public async Task<IActionResult> AddPlayer(int clanId, int playerId)
        {
            try
            {
                await _clanService.AddPlayer(clanId, playerId);
            }
            catch (ModelNotFoundException<ClanModel> e)
            {
                return NotFound(new RequestResponse<ClanModel>(message: e.Message, success: false));
            }
            catch (ModelNotFoundException<PlayerModel> e)
            {
                return NotFound(new RequestResponse<PlayerModel>(message: e.Message, success: false));
            }
            catch (IdNotFoundException<ClanModel, int> e)
            {
                return NotFound(new RequestResponse<ClanModel>(message: e.Message, success: false));
            }
            catch (IdNotFoundException<PlayerModel, int> e)
            {
                return NotFound(new RequestResponse<PlayerModel>(message: e.Message, success: false));
            }
            catch(DbUpdateException e)
            {
                return BadRequest(new RequestResponse<ClanModel>(message: e.InnerException.Message, success: false));
            }

            return Created($"api/clans/{clanId}",  new RequestResponse<ClanModel>(message: "Player Added", success: true));
        }

        [HttpDelete("{clanId:int}/players/{playerId}")]
        public async Task<IActionResult> RemovePlayer(int clanId, int playerId)
        {
            try
            {
                await _clanService.RemovePlayer(clanId, playerId);
            }
            catch (IdNotFoundException<PlayerClansModel, int> e)
            {
                return NotFound(new RequestResponse<PlayerClansModel>(message: e.Message, success: false));
            }

            return NoContent();
        }

        [HttpPatch("{clanId:int}/players/{playerId}/rank/{rank:int}")]
        public async Task<IActionResult> UpdatePlayerRank(int clanId, int playerId, RankClan rank)
        {
            try
            {
                await _clanService.UpdatePlayerRank(clanId, playerId, rank);
            }
            catch (IdNotFoundException<PlayerClansModel, int> e)
            {
                return NotFound(new RequestResponse<PlayerClansModel>(message: e.Message, success: false));
            }

            return Ok();
        }
    }
}
