using AutoMapper;
using ClashRoyaleClanWarsAPI.Dtos.BattleDto;
using ClashRoyaleClanWarsAPI.Dtos.WarDto;
using ClashRoyaleClanWarsAPI.Exceptions;
using ClashRoyaleClanWarsAPI.Interfaces.ServicesInterfaces;
using ClashRoyaleClanWarsAPI.Models;
using ClashRoyaleClanWarsAPI.Services;
using ClashRoyaleClanWarsAPI.Utils;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClashRoyaleClanWarsAPI.Controllers.ModelControllers
{
    [Route("api/battles")]
    [ApiController]
    public class BattleController : ControllerBase
    {
        private readonly IBattleService _battleService;
        private readonly IMapper _mapper;

        public BattleController(IBattleService battleService, IMapper mapper)
        {
            _battleService = battleService;
            _mapper = mapper;
        }
        // GET: api/battles
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<BattleModel>? battles = null;
            try
            {
                battles = await _battleService.GetAllAsync();
            }
            catch (ModelNotFoundException<BattleModel> e)
            {
                return NotFound(new RequestResponse<BattleModel>(message: e.Message, success: false));
            }

            return Ok(new RequestResponse<IEnumerable<BattleModel>>(battles!));
        }

        // GET api/battles/{battleId:Guid}
        [HttpGet("{battleId:Guid}")]
        public async Task<IActionResult> Get(Guid battleId)
        {
            BattleModel? battle = null;

            try
            {
                battle = await _battleService.GetSingleByIdAsync(battleId, true);
            }
            catch (ModelNotFoundException<BattleModel> e)
            {
                return NotFound(new RequestResponse<BattleModel>(message: e.Message, success: false));
            }
            catch (IdNotFoundException<BattleModel> e)
            {
                return NotFound(new RequestResponse<BattleModel>(message: e.Message, success: false));
            }

            return Ok(new RequestResponse<BattleModel>(battle!));
        }

        // POST api/battles
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddBattleDto warDto)
        {
            BattleModel battle = _mapper.Map<BattleModel>(warDto);

            try
            {
                await _battleService.AddAsync(battle, warDto.WinnerId);
            }
            catch (ModelNotFoundException<BattleModel> e)
            {
                return NotFound(new RequestResponse<BattleModel>(message: e.Message, success: false));
            }

            return Created($"api/battles/{battle.Id}", new RequestResponse<BattleModel>(data: battle, message: "Battle created", success: true));
        }
    }
}
