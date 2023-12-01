using AutoMapper;
using ClashRoyaleClanWarsAPI.API.Common.Mapping.Objects;
using ClashRoyaleClanWarsAPI.Application.Common.Commands.AddModel;
using ClashRoyaleClanWarsAPI.Application.Common.Queries.GetModelById;
using ClashRoyaleClanWarsAPI.Application.Models.Challenge.Queries.GetAllOpen;
using ClashRoyaleClanWarsAPI.Domain.Errors;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ClashRoyaleClanWarsAPI.Application.Common.Commands.UpdateModel;
using ClashRoyaleClanWarsAPI.Application.Common.Commands.DeleteModel;
using ClashRoyaleClanWarsAPI.Domain.Models;
using ClashRoyaleClanWarsAPI.Application.Common.Queries.GetAllModel;

namespace ClashRoyaleClanWarsAPI.API.Controllers;

[Route("api/challenges")]
public class ChallengeController : ApiController
{
    private readonly IMapper _mapper;
    public ChallengeController(ISender sender, IMapper mapper) : base(sender)
    {
        _mapper = mapper;
    }

    // GET api/challenges/{id:int}
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var quey = new GetModelByIdQuery<ChallengeModel, int>(id);

        var result = await _sender.Send(quey);

        return result.IsSuccess? Ok(result.Value) : Problem(result.Errors);
    }

    // GET api/challenges/
    [HttpGet]
    public async Task<IActionResult> GetAllChallenges()
    {
        var query = new GetAllModelQuery<ChallengeModel, int>();

        var result = await _sender.Send(query);

        return result.IsSuccess ? Ok(result.Value) : Problem(result.Errors);
    }

    // GET api/challenges/open
    [HttpGet("open")]
    public async Task<IActionResult> GetAllOpenChallenges() 
    {
        var query = new GetAllOpenChallengeQuery();

        var result = await _sender.Send(query);

        return result.IsSuccess ? Ok(result.Value) : Problem(result.Errors);
    }

    // POST api/challenges
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AddChallengeRequest challengeRequest)
    {
        var challenge = _mapper.Map<ChallengeModel>(challengeRequest);

        var command = new AddModelCommand<ChallengeModel, int>(challenge);

        var result = await _sender.Send(command);

        return result.IsSuccess? 
            Created($"api/challenges/{result.Value}", result.Value) : 
            Problem(result.Errors);
    }

    // PUT api/challenges/{id:int}
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateChallengeRequest challengeRequest)
    {
        if (id != challengeRequest.Id)
            return Problem(ErrorTypes.Models.IdsNotMatch());

        var challenge = _mapper.Map<ChallengeModel>(challengeRequest);

        var command = new UpdateModelCommand<ChallengeModel, int>(challenge);

        var result  = await _sender.Send(command);

        return result.IsSuccess ? NoContent() : Problem(result.Errors);
    }

    // DELETE api/challenges/{id:int}
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteModelCommand<ChallengeModel, int>(id);

        var result = await _sender.Send(command);

        return result.IsSuccess ? NoContent() : Problem(result.Errors);
    }
}
