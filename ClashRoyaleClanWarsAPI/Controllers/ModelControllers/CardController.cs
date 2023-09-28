using ClashRoyaleClanWarsAPI.Exceptions;
using ClashRoyaleClanWarsAPI.Interfaces.ServicesInterfaces;
using ClashRoyaleClanWarsAPI.Models;
using ClashRoyaleClanWarsAPI.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ClashRoyaleClanWarsAPI.Controllers.ModelControllers
{
    [Route("api/cards")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardService<CardModel> _cardService;
        
        public CardController(ICardService<CardModel> cardService)
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
                NotFound(new RequestResponse<CardModel>(null!, e.Message, false));
            }
            catch (IdNotFoundException<CardModel> e)
            {
                NotFound(new RequestResponse<CardModel>(null!, e.Message, false));
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
                NotFound(new RequestResponse<CardModel>(null!, e.Message, false));
            }

            return Ok(new RequestResponse<IEnumerable<CardModel>>(cards!));
        }
        
        // POST api/cards
        [HttpPost("seed")]
        public async Task<ActionResult<RequestResponse<CardModel>>> PostAllCards()
        {
            try
            {
                await _cardService.AddAllCards();
            }
            catch (ModelNotFoundException<CardModel> e)
            {
                NotFound(new RequestResponse<CardModel>(null!, e.Message, false));
            }

            return Created("api/cards", new RequestResponse<IEnumerable<CardModel>>(null!));
        }

        // PUT api/cards/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] CardModel cardModel)
        {
            if (id != cardModel.Id) return BadRequest(new RequestResponse<CardModel>(null!, "Ids do not match", false));
            try
            {
                await _cardService.Update(cardModel);
            }
            catch (ModelNotFoundException<CardModel> e)
            {
                NotFound(new RequestResponse<CardModel>(null!, e.Message, false));
            }
            catch (IdNotFoundException<CardModel> e)
            {
                NotFound(new RequestResponse<CardModel>(null!, e.Message, false));
            }

            return NoContent();
        }

        // DELETE api/cards/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _cardService.Delete(id);
            }
            catch (ModelNotFoundException<CardModel> e)
            {
                NotFound(new RequestResponse<CardModel>(null!, e.Message, false));
            }
            catch (IdNotFoundException<CardModel> e)
            {
                NotFound(new RequestResponse<CardModel>(null!, e.Message, false));
            }

            return NoContent();
        }
    }
}
