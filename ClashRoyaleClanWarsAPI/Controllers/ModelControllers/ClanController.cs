using AutoMapper;
using ClashRoyaleClanWarsAPI.Dtos.ClanDto;
using ClashRoyaleClanWarsAPI.Exceptions;
using ClashRoyaleClanWarsAPI.Interfaces.ServicesInterfaces;
using ClashRoyaleClanWarsAPI.Models;
using ClashRoyaleClanWarsAPI.Services;
using ClashRoyaleClanWarsAPI.Utils;
using Microsoft.AspNetCore.Mvc;

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

        // GET api/clans/{id:int}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            ClanModel? clan = null;

            try
            {
                clan = await _clanService.GetSingleByIdAsync(id);
            }
            catch (ModelNotFoundException<ClanModel> e)
            {
                return NotFound(new RequestResponse<ClanModel>(message: e.Message, success: false));
            }
            catch (IdNotFoundException<ClanModel> e)
            {
                return NotFound(new RequestResponse<ClanModel>(message: e.Message, success: false));
            }

            return Ok(new RequestResponse<ClanModel>(clan!));
        }

        // POST api/clans/{playerId:int}
        [HttpPost("{playerId:int}")]
        public async Task<IActionResult> Post(int playerId, [FromBody] AddClanDto clanDto)
        {
            ClanModel clan = null!;

            try
            {
                clan = _mapper.Map<ClanModel>(clanDto);
                await _clanService.Add(clan);
            }
            catch (ModelNotFoundException<ClanModel> e)
            {
                return NotFound(new RequestResponse<ClanModel>(message: e.Message, success: false));
            }
            catch (IdNotFoundException<PlayerModel> e)
            {
                return NotFound(new RequestResponse<PlayerModel>(message: e.Message, success: false));
            }

            return Created($"api/clans/{clan.Id}", clan);

            
        }

        // PUT api/clans/{id:int}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateClanDto clanDto)
        {
            if (id != clanDto.Id)
                return BadRequest(new RequestResponse<ClanModel>(message: "Ids do not match", success: false));

            try
            {
                await _clanService.Update(_mapper.Map<ClanModel>(clanDto));
            }
            catch (ModelNotFoundException<ClanModel> e)
            {
                return NotFound(new RequestResponse<ClanModel>(message: e.Message, success: false));
            }
            catch (IdNotFoundException<PlayerModel> e)
            {
                return NotFound(new RequestResponse<PlayerModel>(message: e.Message, success: false));
            }

            return NoContent();
        }

        // DELETE api/clans/{id:int}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _clanService.Delete(id);
            }
            catch (ModelNotFoundException<ClanModel> e)
            {
                return NotFound(new RequestResponse<ClanModel>(message: e.Message, success: false));
            }
            catch (IdNotFoundException<ClanModel> e)
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
    }
}
