using AutoMapper;
using ClashRoyaleClanWarsAPI.API.Common.Mapping.Objects;
using ClashRoyaleClanWarsAPI.API.Common.Mapping.Utils;
using ClashRoyaleClanWarsAPI.Application.Common.Commands.DeleteModel;
using ClashRoyaleClanWarsAPI.Application.Common.Commands.UpdateModel;
using ClashRoyaleClanWarsAPI.Application.Common.Queries.GetAllModel;
using ClashRoyaleClanWarsAPI.Application.Common.Queries.GetModelById;
using ClashRoyaleClanWarsAPI.Application.Models.Card.Queries.GetCardsByName;
using ClashRoyaleClanWarsAPI.Domain.Errors;
using ClashRoyaleClanWarsAPI.Domain.Models.Card;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClashRoyaleClanWarsAPI.API.Controllers;

[Route("api/cards")]
public class CardController : ApiController
{
    private readonly IMapper _mapper;
    public CardController(ISender sender, IMapper mapper) : base(sender)
    {
        _mapper = mapper;
    }

    // GET api/cards/{id:int}
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var query = new GetModelByIdQuery<CardModel, int>(id);

        var result = await _sender.Send(query);

        return result.IsSuccess ? Ok(result.Value) : Problem(result.Errors);

    }

    // GET api/cards
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllModelQuery<CardModel, int>();

        var result = await _sender.Send(query);

        return Ok(result.Value);
    }

    // GET api/cards/{name:string}
    [HttpGet("{name}")]
    public async Task<IActionResult> GetCardsByName(string name)
    {
        var query = new GetCardsByNameQuery(name);

        var result = await _sender.Send(query);

        return Ok(result.Value);
    }

    // PUT api/cards/{id:int}
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put(int id, [FromBody] CardRequest cardRequest)
    {
        if (id != cardRequest.Id)
            return Problem(ErrorTypes.Models.IdsNotMatch());

        var card = MapCardFromTypeEnum.MapCard(cardRequest, _mapper);

        if (card == null)
            return Problem();

        var command = new UpdateModelCommand<CardModel, int>(card);

        await _sender.Send(command);

        return NoContent();
    }

    // DELETE api/cards/{id:int}
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var commandDelete = new DeleteModelCommand<CardModel, int>(id);

        var result = await _sender.Send(commandDelete);

        return result.IsSuccess ? NoContent() : Problem(result.Errors);
    }
}
