using AutoMapper;
using ClashRoyaleClanWarsAPI.Dtos.PlayerDto;
using ClashRoyaleClanWarsAPI.Exceptions;
using ClashRoyaleClanWarsAPI.Interfaces.ServicesInterfaces;
using ClashRoyaleClanWarsAPI.Models;
using ClashRoyaleClanWarsAPI.Services;
using ClashRoyaleClanWarsAPI.Utils;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClashRoyaleClanWarsAPI.Controllers.ModelControllers
{
    [Route("api/players")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;
        private readonly IMapper _mapper;

        public PlayerController(IPlayerService playerService, IMapper mapper)
        {
            _playerService = playerService;
            _mapper = mapper;
        }

        // GET: api/players
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<PlayerModel>? players = null;
            try
            {
                players = await _playerService.GetAllAsync();
            }
            catch (ModelNotFoundException<PlayerModel> e)
            {
                NotFound(new RequestResponse<PlayerModel>(message: e.Message, success: false));
            }

            return Ok(new RequestResponse<IEnumerable<PlayerModel>>(players!));
        }

        // GET api/players/{id:int}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            PlayerModel? player = null;

            try
            {
                player = await _playerService.GetSingleByIdAsync(id, true);
            }
            catch (ModelNotFoundException<PlayerModel> e)
            {
                return NotFound(new RequestResponse<PlayerModel>(message: e.Message, success: false));
            }
            catch (IdNotFoundException<PlayerModel> e)
            {
                return NotFound(new RequestResponse<PlayerModel>(message: e.Message, success: false));
            }

            return Ok(new RequestResponse<PlayerModel>(player!));
        }

        // GET api/players/{alias}
        [HttpGet("{alias}")]
        public async Task<IActionResult> GetAllByAlias(string alias)
        {
            IEnumerable<PlayerModel>? players = null;
            try
            {
                players = await _playerService.GetPlayersByAliasAsync(alias);
            }
            catch (ModelNotFoundException<PlayerModel> e)
            {
                return NotFound(new RequestResponse<PlayerModel>(message: e.Message, success: false));
            }

            return Ok(new RequestResponse<IEnumerable<PlayerModel>>(players!));
        }
        
        // POST api/players
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddPlayerDto playerDto)
        {
            int playerId;
            PlayerModel player;
            try
            {
                player = _mapper.Map<PlayerModel>(playerDto);
                playerId = await _playerService.Add(player);
            }
            catch (ModelNotFoundException<PlayerModel> e)
            {
                return NotFound(new RequestResponse<PlayerModel>(message: e.Message, success: false));
            }

            return Created($"api/players/{playerId}", new RequestResponse<PlayerModel>(player, "Created Successfully"));
        }

        // PUT api/players/{id:int}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdatePlayerDto playerModel)
        {
            if (id != playerModel.Id) 
                return BadRequest(new RequestResponse<PlayerModel>(message:"Ids do not match", success: false));
            try
            {
                await _playerService.Update(_mapper.Map<PlayerModel>(playerModel));
            }
            catch (ModelNotFoundException<PlayerModel> e)
            {
                return NotFound(new RequestResponse<PlayerModel>(message:e.Message, success: false));
            }
            catch (IdNotFoundException<PlayerModel> e)
            {
                return NotFound(new RequestResponse<PlayerModel>(message: e.Message, success: false));
            }

            return NoContent();
        }

        // DELETE api/players/{id:int}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _playerService.Delete(id);
            }
            catch (ModelNotFoundException<PlayerModel> e)
            {
                return NotFound(new RequestResponse<PlayerModel>(message: e.Message, success: false));
            }
            catch (IdNotFoundException<PlayerModel> e)
            {
                return NotFound(new RequestResponse<PlayerModel>(message: e.Message, success: false));
            }

            return NoContent();
        }

        // GET api/players/{id:int}/cards
        [HttpGet("{id:int}/cards")]
        public async Task<IActionResult> GetCards(int id)
        {
            IEnumerable<CardModel> cards = null!;
            try
            {
                cards = await _playerService.GetAllCardsOfPlayerAsync(id);

            }
            catch (ModelNotFoundException<PlayerModel> e)
            {
                return NotFound(new RequestResponse<PlayerModel>(message: e.Message, success: false));
            }
            catch (IdNotFoundException<PlayerModel> e)
            {
                return NotFound(new RequestResponse<PlayerModel>(message: e.Message, success: false));
            }

            return Ok(new RequestResponse<IEnumerable<CardModel>>(cards!));
        }
        // GET api/players/{playerId:int}/cards/{cardId:int}
        [HttpPost("{playerId:int}/cards/{cardId:int}")]
        public async Task<IActionResult> AddCard(int playerId, int cardId)
        {
            try
            {
                await _playerService.AddCard(playerId, cardId);

            }
            catch (ModelNotFoundException<PlayerModel> e)
            {
                return NotFound(new RequestResponse<PlayerModel>(message: e.Message, success: false));
            }
            catch (ModelNotFoundException<CardModel> e)
            {
                return NotFound(new RequestResponse<CardModel>(message: e.Message, success: false));
            }

            return NoContent();
        }

        //PATCH api/players/{playerId:int}/{alias}
        [HttpPatch("{playerId:int}/{alias}")]
        public async Task<IActionResult> UpdateAlias(int playerId, string alias)
        {
            PlayerModel player = null!;
            try
            {
                player = await _playerService.UpdateAlias(playerId, alias);
            }
            catch (ModelNotFoundException<PlayerModel> e)
            {
                return NotFound(new RequestResponse<PlayerModel>(message: e.Message, success: false));
            }
            catch (IdNotFoundException<PlayerModel> e)
            {
                return NotFound(new RequestResponse<PlayerModel>(message: e.Message, success: false));
            }

            return Ok(new RequestResponse<PlayerModel>(data: player!, message: "Alias Updated", success: true));

        }
    }
}
