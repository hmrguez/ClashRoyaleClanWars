using System.Runtime.InteropServices.JavaScript;
using AutoMapper;
using ClashRoyaleClanWarsAPI.API.Common.Mapping.Objects;
using ClashRoyaleClanWarsAPI.Application.Common.Commands.AddModel;
using ClashRoyaleClanWarsAPI.Application.Models.Battle.Command.AddBattle;
using ClashRoyaleClanWarsAPI.Application.Models.Clan.Commands.AddPlayerClan;
using ClashRoyaleClanWarsAPI.Application.Models.Player.Commands.AddChallengeResult;
using ClashRoyaleClanWarsAPI.Domain.Models;
using ClashRoyaleClanWarsAPI.Domain.Models.Battle;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClashRoyaleClanWarsAPI.API.Controllers;

[Route("api/dummy")]
public class DummyController: ApiController
{

    private readonly IMapper _mapper;
    public DummyController(ISender sender, IMapper mapper) : base(sender)
    {
        _mapper = mapper;
    }
    
    [HttpGet("/seed")]
    public async Task<IActionResult> Seed()
    {
        string[] names = { "Gabe", "Nathan", "Gail", "Fabian", "Raphael", "Leonardo", "Donatello", "Splinter", "Gojo", "Guillermo", "Bruce", "Peter", "Megan", "Louis", "Chris", "Brian", "Stewart" };
        string[] lastNames = { "Rodriguez", "Sanchez", "Smith", "Biden", "Trump", "Obama", "Satoru", "Hizoka", "Diaz", "Wayne", "Stark", "Kent", "Parker", "Lane", "Banner", "Tomlinson", "Harris" };
        string[] nouns = { "Dutchman", "French", "Whale", "Dog", "Rat", "Virtual", "Robot", "Window", "Penguin", "Platypus", "Monkey", "Boat", "Truck", "Fighter", "Sniper", "Apple" };
        string[] adjectives = { "Flying", "Roaming", "Gay", "Boring", "Browsing", "Squishy", "Pretty", "Mecha", "Adorable", "Abstract", "Ugly", "Blazing", "Freezing" };
        string[] regions = { "CIS", "WEU", "Africa", "LATAM", "USA", "Canada", "SEA", "Dubai" };
        
        List<int> clanIds = new();
        List<int> challengeIds = new List<int>();
        List<int> playerIds = new List<int>();
        
        var random = new Random();
        
        #region Challenges

        for (int i = 0; i < 24; i++)
        {

            var challengeRequest = new AddChallengeRequest()
            {
                AmountReward = random.Next(100),
                Cost = random.Next(100),
                Name = $"{GetRandomFromArray(nouns)} in {GetRandomFromArray(regions)}",
                IsOpen = random.Next(1) == 0,
                DurationInHours = random.Next(72),
                MinLevel = random.Next(11),
                LossLimit = random.Next(5),
                StartDate = DateTime.Today,
                Description = $"{GetRandomFromArray(nouns)} in {GetRandomFromArray(regions)}",
            };
            var challenge = _mapper.Map<ChallengeModel>(challengeRequest);
            var command = new AddModelCommand<ChallengeModel, int>(challenge);
            
            var result = await _sender.Send(command);
            
            if(result.IsFailure) continue;
            challengeIds.Add(result.Value);
        }

        #endregion

        #region Clans

        for (int i = 0; i < 100; i++)
        {
            var clanRequest = new AddClanRequest()
            {
                MinTrophies = random.Next(4000),
                Name = $"The {GetRandomFromArray(adjectives)} {GetRandomFromArray(nouns)}s",
                Region = GetRandomFromArray(regions),
                TypeOpen = random.Next(1) == 0
            };
            
            var clan = _mapper.Map<ClanModel>(clanRequest);
            var command = new AddModelCommand<ClanModel, int>(clan);
            var result = await _sender.Send(command);
            clanIds.Add(result.Value);
        }

        #endregion

        #region Players

        for (int i = 0; i < 50; i++)
        {
            var playerRequest = new AddPlayerRequest()
            {
                Alias = GetRandomFromArray(names) + " " + GetRandomFromArray(lastNames),
                Elo = random.Next(5000),
                Level = random.Next(13)
            };
            
            var player = _mapper.Map<PlayerModel>(playerRequest);
            var command = new AddModelCommand<PlayerModel, int>(player);
            var playerId = (await _sender.Send(command)).Value;
            playerIds.Add(playerId);
            
            var addPlayerClan = new AddPlayerClanCommand(GetRandomFromArray(clanIds), playerId);
            await _sender.Send(addPlayerClan);
            
            var addChallenge = new AddChallengeResultCommand(playerId, GetRandomFromArray(challengeIds), random.Next(100));
            await _sender.Send(addChallenge);
        }

        #endregion
        
        #region Battles

        for (int i = 0; i < 200; i++)
        {
            var firstPlayer = GetRandomFromArray(playerIds);
            var secondPlayer = GetRandomFromArray(playerIds);

            while (firstPlayer == secondPlayer) secondPlayer = GetRandomFromArray(playerIds);

            var battleRequest = new AddBattleRequest()
            {
                AmountTrophies = random.Next(25),
                DurationInSeconds = random.Next(150),
                LoserId = firstPlayer,
                WinnerId = secondPlayer
            };
            
            var battle = _mapper.Map<BattleModel>(battleRequest);
            var command = new AddBattleCommand(battle, battleRequest.WinnerId, battleRequest.LoserId);

            await _sender.Send(command);
        }

        #endregion

        #region WarController

        for (int i = 0; i < 10; i++)
        {
            var warRequest = new AddWarRequest()
            {
                StartDate = DateTime.Today
            };
            var war = _mapper.Map<WarModel>(warRequest);

            var command = new AddModelCommand<WarModel, int>(war);

            await _sender.Send(command);
        }

        #endregion
        
        return Ok();
    }

    private static T GetRandomFromArray<T>(IReadOnlyList<T> array) => array[new Random().Next(array.Count)];
}