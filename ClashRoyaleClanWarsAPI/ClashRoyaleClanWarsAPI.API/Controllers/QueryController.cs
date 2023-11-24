using ClashRoyaleClanWarsAPI.Application.Common.Queries.GetModelById;
using ClashRoyaleClanWarsAPI.Application.Interfaces;
using ClashRoyaleClanWarsAPI.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClashRoyaleClanWarsAPI.API.Controllers;

[Route("queries")]
public class QueryController : ApiController
{
    private readonly IPredefinedQueries _queries;
    public QueryController(IMediator sender, IPredefinedQueries queries) : base(sender)
    {
        _queries = queries;
    }

    // GET api/queries/firstquery
    [HttpGet("firstquery")]
    public async Task<IActionResult> GetFirstQuery()
    {
        var result = await _queries.FirstQuery();

        return Ok(result);
    }

    // GET api/queries/secondquery
    [HttpGet("secondquery")]
    public async Task<IActionResult> GetSecondQuery()
    {
        var result = await _queries.SecondQuery();

        return Ok(result);
    }

    // GET api/queries/thirdquery
    [HttpGet("thirdquery")]
    public async Task<IActionResult> GetThirdQuery()
    {
        var result = await _queries.ThirdQuery();

        return Ok(result);
    }

    // GET api/queries/fourthquery
    [HttpGet("fourthquery")]
    public async Task<IActionResult> GetFourthQuery()
    {
        var result = await _queries.FourthQuery();

        return Ok(result);
    }

    // GET api/queries/fifthquery/{playerId:int}
    [HttpGet("fifthquery/{playerId:int}")]
    public async Task<IActionResult> GetFifthQuery(int playerId)
    {
        var queryPlayer = new GetModelByIdQuery<PlayerModel, int>(playerId);

        var resultPlayer = await _sender.Send(queryPlayer);

        if (!resultPlayer.IsSuccess)
            return Problem(resultPlayer.Errors);

        var result = await _queries.FifthQuery(resultPlayer.Value.Elo);

        return Ok(result);
    }

    // GET api/queries/sixthquery
    [HttpGet("sixthquery")]
    public async Task<IActionResult> GetSixthQuery()
    {
        var result = await _queries.SixthQuery();

        return Ok(result);
    }

    // GET api/queries/seventhquery/{year:int}
    [HttpGet("seventhquery/{year:int}")]
    public async Task<IActionResult> GetSeventhQuery(int year)
    {
        var result = await _queries.SeventhQuery(year);

        return Ok(result);
    }
}
