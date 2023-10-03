using ClashRoyaleClanWarsAPI.Exceptions;
using ClashRoyaleClanWarsAPI.Interfaces.ServicesInterfaces;
using ClashRoyaleClanWarsAPI.Models;
using ClashRoyaleClanWarsAPI.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClashRoyaleClanWarsAPI.Controllers.ModelControllers
{
    [Route("api/cards")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardService _cardService;
        
        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }
        // GET api/cards/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<RequestResponse<object>>> Get(int id)
        {
            CardModel? card = null;

            try
            {
                card = await _cardService.GetSingleByIdAsync(id);
            }
            catch (ModelNotFoundException<CardModel> e)
            {
                return NotFound(new RequestResponse<CardModel>(message: e.Message, success: false));
            }
            catch (IdNotFoundException<CardModel> e)
            {
                return NotFound(new RequestResponse<CardModel>(message: e.Message, success: false));
            }

            return Ok(new RequestResponse<CardModel>(card!));
        }

        // GET api/cards
        [HttpGet]
        public async Task<ActionResult<RequestResponse<CardModel>>> GetAll()
        {
            IEnumerable<CardModel>? cards = null;
            try
            {
                cards = await _cardService.GetAllAsync();
            }
            catch (ModelNotFoundException<CardModel> e)
            {
                return NotFound(new RequestResponse<CardModel>(message: e.Message, success: false));
            }

            return Ok(new RequestResponse<IEnumerable<CardModel>>(cards!));
        }

        // POST api/cards
        [Authorize(Roles = UserRoles.SUPERADMIN)]
        [HttpPost("seed")]
        public async Task<ActionResult<RequestResponse<CardModel>>> PostAllCards()
        {
            try
            {
                await _cardService.AddAllCards();
            }
            catch (ModelNotFoundException<CardModel> e)
            {
                return NotFound(new RequestResponse<CardModel>(message: e.Message, success: false));
            }

            return Created("api/cards", new RequestResponse<IEnumerable<CardModel>>());
        }

        // PUT api/cards/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] CardModel cardModel)
        {
            if (id != cardModel.Id) 
                return BadRequest(new RequestResponse<CardModel>(message: "Ids do not match", success: false));
            try
            {
                await _cardService.Update(cardModel);
            }
            catch (ModelNotFoundException<CardModel> e)
            {
                return NotFound(new RequestResponse<CardModel>(message: e.Message, success: false));
            }
            catch (IdNotFoundException<CardModel> e)
            {
                return NotFound(new RequestResponse<CardModel>(message: e.Message, success: false));
            }

            return NoContent();
        }

        // DELETE api/cards/5
        [Authorize(Roles = UserRoles.SUPERADMIN)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _cardService.Delete(id);
            }
            catch (ModelNotFoundException<CardModel> e)
            {
                return NotFound(new RequestResponse<CardModel>(message: e.Message, success: false));
            }
            catch (IdNotFoundException<CardModel> e)
            {
                return NotFound(new RequestResponse<CardModel>(message: e.Message, success: false));
            }

            return NoContent();
        }
    }
}
