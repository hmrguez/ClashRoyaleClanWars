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
        // GET api/cards/{id:int}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
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
            catch (IdNotFoundException<CardModel, int> e)
            {
                return NotFound(new RequestResponse<CardModel>(message: e.Message, success: false));
            }

            return Ok(new RequestResponse<CardModel>(card!));
        }

        // GET api/cards
        [HttpGet]
        public async Task<IActionResult> GetAll()
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
        public async Task<IActionResult> PostAllCards()
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

        // PUT api/cards/{id:int}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody] CardModel cardModel)
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
            catch (IdNotFoundException<CardModel, int> e)
            {
                return NotFound(new RequestResponse<CardModel>(message: e.Message, success: false));
            }

            return NoContent();
        }

        // DELETE api/cards/{id:int}
        [Authorize(Roles = UserRoles.SUPERADMIN)]
        [HttpDelete("{id:int}")]
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
            catch (IdNotFoundException<CardModel, int> e)
            {
                return NotFound(new RequestResponse<CardModel>(message: e.Message, success: false));
            }

            return NoContent();
        }
    }
}
