using AutoMapper;
using ClashRoyaleClanWarsAPI.API.Common.Mapping.Objects;
using ClashRoyaleClanWarsAPI.Application.Common.Commands.DeleteModel;
using ClashRoyaleClanWarsAPI.Application.Common.Commands.UpdateModel;
using ClashRoyaleClanWarsAPI.Application.Common.Queries.GetAllModel;
using ClashRoyaleClanWarsAPI.Application.Models.Clan.Commands.AddClan;
using ClashRoyaleClanWarsAPI.Application.Models.Clan.Commands.AddPlayerClan;
using ClashRoyaleClanWarsAPI.Application.Models.Clan.Commands.RemovePlayerClan;
using ClashRoyaleClanWarsAPI.Application.Models.Clan.Commands.UpdatePlayerRank;
using ClashRoyaleClanWarsAPI.Application.Models.Clan.Queries.GetAllClanByName;
using ClashRoyaleClanWarsAPI.Application.Models.Clan.Queries.GetAllPlayers;
using ClashRoyaleClanWarsAPI.Application.Models.Clan.Queries.GetClanAvailables;
using ClashRoyaleClanWarsAPI.Application.Models.Clan.Queries.GetClanByIdFullLoad;
using ClashRoyaleClanWarsAPI.Domain.Enum;
using ClashRoyaleClanWarsAPI.Domain.Errors;
using ClashRoyaleClanWarsAPI.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClashRoyaleClanWarsAPI.API.Controllers;

[Route("api/clans")]
public class ClanController : ApiController
{
    private readonly IMapper _mapper;
    public ClanController(ISender sender, IMapper mapper) : base(sender)
    {
        _mapper = mapper;
    }

    // GET: api/clans
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllModelQuery<ClanModel, int>();

        var result = await _sender.Send(query);

        return result.IsSuccess ? Ok(result.Value) : Problem(result.Errors);
    }

    // GET api/clans/{clanId:int}
    [HttpGet("{clanId:int}")]
    public async Task<IActionResult> Get(int clanId)
    {
        var query = new GetClanByIdFullLoadQuery(clanId, true);

        var result = await _sender.Send(query);

        return result.IsSuccess ? Ok(result.Value) : Problem(result.Errors);
    }

    // POST api/clans/{playerId:int}
    [HttpPost("{playerId:int}")]
    public async Task<IActionResult> Post(int playerId, [FromBody] AddClanRequest clanRequest)
    {
        var clan = _mapper.Map<ClanModel>(clanRequest);

        var command = new AddClanCommand(playerId, clan);

        var result = await _sender.Send(command);

        return result.IsSuccess ?
            Created($"api/clans/{result.Value}", result.Value)
            : Problem(result.Errors);
    }

    // PUT api/clans/{clanId:int}
    [HttpPut("{clanId:int}")]
    public async Task<IActionResult> Put(int clanId, [FromBody] UpdateClanRequest clanRequest)
    {
        if (clanId != clanRequest.Id)
            return Problem(ErrorTypes.Models.IdsNotMatch());

        var clan = _mapper.Map<ClanModel>(clanRequest);

        var command = new UpdateModelCommand<ClanModel, int>(clan);

        var result = await _sender.Send(command);

        return result.IsSuccess ? NoContent() : Problem(result.Errors);
    }

    // DELETE api/clans/{clanId:int}
    [HttpDelete("{clanId:int}")]
    public async Task<IActionResult> Delete(int clanId)
    {
        var command = new DeleteModelCommand<ClanModel, int>(clanId);

        var result = await _sender.Send(command);

        return result.IsSuccess ? NoContent() : Problem(result.Errors);
    }

    // GET api/clans/availables/{trophies:int}
    [HttpGet("availables/{trophies:int}")]
    public async Task<IActionResult> GetClanAvailables(int trophies)
    {
        var query = new GetClanAvailablesQuery(trophies);

        var result = await _sender.Send(query);

        return result.IsSuccess ? Ok(result.Value) : Problem(result.Errors);
    }

    // GET api/clans/name/{clanName}
    [HttpGet("name/{clanName}")]
    public async Task<IActionResult> GetClansByName(string clanName)
    {
        var query = new GetAllClanByNameQuery(clanName);

        var result = await _sender.Send(query);

        return result.IsSuccess ? Ok(result.Value) : Problem(result.Errors);
    }

    // GET api/clans/{clanId:int}/players
    [HttpGet("{clanId:int}/players")]
    public async Task<IActionResult> GetPlayers(int clanId)
    {
        var query = new GetAllPlayersQuery(clanId);

        var result = await _sender.Send(query);

        return result.IsSuccess ? Ok(result.Value) : Problem(result.Errors);
    }

    // POST api/clans/{clanId:int}/players/{playerId:int}
    [HttpPost("{clanId:int}/players/{playerId:int}")]
    public async Task<IActionResult> AddPlayer(int clanId, int playerId)
    {
        var command = new AddPlayerClanCommand(clanId, playerId);

        var result = await _sender.Send(command);

        return result.IsSuccess ? NoContent() : Problem(result.Errors);
    }

    // DELETE api/clans/{clanId:int}/players/{playerId:int}
    [HttpDelete("{clanId:int}/players/{playerId:int}")]
    public async Task<IActionResult> RemovePlayer(int clanId, int playerId)
    {
        var command = new RemovePlayerClanCommand(clanId, playerId);

        var result = await _sender.Send(command);

        return result.IsSuccess ? NoContent() : Problem(result.Errors);
    }

    // PATCH api/clans/{clanId:int}/players/{playerId}/rank/{rank:int}
    [HttpPatch("{clanId:int}/players/{playerId:int}/rank/{rank:int}")]
    public async Task<IActionResult> UpdatePlayerRank(int clanId, int playerId, RankClan rank)
    {
        var command = new UpdatePlayerRankCommand(clanId, playerId, rank);

        var result = await _sender.Send(command);

        return result.IsSuccess ? NoContent() : Problem(result.Errors);
    }
}
