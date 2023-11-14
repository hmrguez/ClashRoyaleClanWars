using System.Runtime.InteropServices.JavaScript;
using System.Security.Claims;
using AutoMapper;
using ClashRoyaleClanWarsAPI.API.Common.Mapping.Objects;
using ClashRoyaleClanWarsAPI.Application.Common.Commands.AddModel;
using ClashRoyaleClanWarsAPI.Application.Common.Commands.UpdateModel;
using ClashRoyaleClanWarsAPI.Application.Models.Battle.Command.AddBattle;
using ClashRoyaleClanWarsAPI.Application.Models.Clan.Commands.AddClanWithCreator;
using ClashRoyaleClanWarsAPI.Application.Models.Clan.Commands.AddPlayerClan;
using ClashRoyaleClanWarsAPI.Application.Models.Player.Commands.AddCard;
using ClashRoyaleClanWarsAPI.Application.Models.Player.Commands.AddChallengePlayer;
using ClashRoyaleClanWarsAPI.Application.Models.Player.Commands.AddDonation;
using ClashRoyaleClanWarsAPI.Application.Models.Player.Commands.UpdateChallengeResult;
using ClashRoyaleClanWarsAPI.Application.Models.War.Commands.AddClanWar;
using ClashRoyaleClanWarsAPI.Domain.Models;
using ClashRoyaleClanWarsAPI.Domain.Models.Battle;
using ClashRoyaleClanWarsAPI.Infrastructure.Persistance;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClashRoyaleClanWarsAPI.API.Controllers;

[Route("api/dummy")]
public class DummyController: ApiController
{
    private readonly ClashRoyaleDbContext _context;
    private readonly IMapper _mapper;
    public DummyController(ISender sender, IMapper mapper, ClashRoyaleDbContext context) : base(sender)
    {
        _mapper = mapper;
        _context = context;
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
        List<int> challengeIds = new();
        List<int> playerIds = new();
        List<ClanModel> clans = new();
        
        var random = new Random();


        var challengePlayerDict = new Dictionary<int, List<int>>();
        var playerClanDict = new Dictionary<int, List<int>>();
        var playerCardsDict = new Dictionary<int, List<int>>();

        #region Challenges

        for (int i = 0; i < 12; i++)
        {

            var challengeRequest = new AddChallengeRequest()
            {
                AmountReward = random.Next(1, 100),
                Cost = random.Next(100),
                Name = $"{GetRandomFromArray(nouns)} in {GetRandomFromArray(regions)}",
                IsOpen = true,
                DurationInHours = random.Next(48, 72),
                MinLevel = random.Next(1, 15),
                LossLimit = random.Next(3, 6),
                StartDate = DateTime.Today,
                Description = $"{GetRandomFromArray(nouns)} in {GetRandomFromArray(regions)}",
            };
            var challenge = _mapper.Map<ChallengeModel>(challengeRequest);
            var command = new AddModelCommand<ChallengeModel, int>(challenge);
            
            var result = await _sender.Send(command);
            
            if(result.IsFailure) 
                continue;

            challengeIds.Add(result.Value);
            challengePlayerDict.Add(result.Value, new List<int>());
        }

        #endregion


        #region Players

        for (int i = 0; i < 50; i++)
        {
            var playerRequest = new AddPlayerRequest()
            {
                Alias = GetRandomFromArray(names) + " " + GetRandomFromArray(lastNames),
                Elo = random.Next(1, 9000),
                Level = random.Next(1, 14)
            };

            var player = _mapper.Map<PlayerModel>(playerRequest);
            var command = new AddModelCommand<PlayerModel, int>(player);
            var result = await _sender.Send(command);

            if (result.IsFailure)
                continue;

            var playerId = result.Value;

            playerIds.Add(playerId);

            var challengeId = GetRandomFromArray(challengeIds);

            var addChallenge = new AddChallengePlayerCommand(playerId, challengeId, random.Next(100));
            await _sender.Send(addChallenge);

            challengePlayerDict[challengeId].Add(playerId);
        }
        #endregion

        var playerIdsBooleanMask = new bool[playerIds.Count];
        var playerIdsForClanBooleanMask = new bool[playerIds.Count];

        #region Clans


        for (int i = 0; i < 10; i++)
        {
            var clanRequest = new AddClanRequest()
            {
                MinTrophies = 0,
                Name = $"The {GetRandomFromArray(adjectives)} {GetRandomFromArray(nouns)}s",
                Description = $"{GetRandomFromArray(nouns)} in {GetRandomFromArray(regions)}",
                Region = GetRandomFromArray(regions),
                TypeOpen = true,
                TrophiesInWar = random.Next(1, 3000)
            };
            
            var clan = _mapper.Map<ClanModel>(clanRequest);

            int playerIdForClan = GetRandomFromArray(playerIds);
            int playerIdForClanIndex = playerIds.IndexOf(playerIdForClan);

            while (playerIdsBooleanMask[playerIdForClanIndex])
            {
                playerIdForClan = GetRandomFromArray(playerIds);
                playerIdForClanIndex = playerIds.IndexOf(playerIdForClan);
            }

            var command = new AddClanWithCreatorCommand(playerIdForClan, clan);
            var result = await _sender.Send(command);

            if (result.IsFailure) 
                continue;

            playerIdsForClanBooleanMask[playerIdForClanIndex] = true;

            clanIds.Add(result.Value);
            clans.Add(clan);
            
            playerClanDict.Add(result.Value, new List<int>());
            playerClanDict[result.Value].Add(playerIdForClan);
        }

        #endregion

        var clanWarBooleanMask = new bool[clanIds.Count];

        #region PlayerClans

        for (int i = 0; i < playerIds.Count; i++)
        {
            int clanId = GetRandomFromArray(clanIds);
            int playerId = playerIds[i];
            int playerIndex = playerIds.IndexOf(playerId);

            if (playerIdsForClanBooleanMask[playerIndex])
                continue;

            var addPlayerClan = new AddPlayerClanCommand(clanId, playerId);
            var result = await _sender.Send(addPlayerClan);

            if (result.IsFailure)
                continue;
            
            playerIdsForClanBooleanMask[playerIndex] = true;
            playerClanDict[clanId].Add(playerId);
        }

        #endregion

        #region UpdateClanStats

        var clanUpdateBooleanMask = new bool[clanIds.Count];

        for (int i = 0; i < 10; i++)
        {
            var clanId = GetRandomFromArray(clanIds);
            var clanIdIndex = clanIds.IndexOf(clanId);

            while (clanUpdateBooleanMask[clanIdIndex])
            {
                clanId = GetRandomFromArray(clanIds);
                clanIdIndex = clanIds.IndexOf(clanId);
            }

            var clan = clans[clanIdIndex];

            if (random.Next(2) != 0)
                clan.ChangeTypeOpen();

            clan.AddMinTrophies(random.Next(1, 5000));

            var command = new UpdateModelCommand<ClanModel, int>(clan);
            var result = await _sender.Send(command);

            if (result.IsSuccess)
                clanUpdateBooleanMask[clanIdIndex] = true;
        
        }
        #endregion

        #region PlayerChallengeCompleted

        for (int i = 0; i < 30; i++)
        {
            var challengeId = GetRandomFromArray(challengeIds);

            if (challengePlayerDict[challengeId].Count == 0)
                continue;

            var playerId = GetRandomFromArray(challengePlayerDict[challengeId]);

            var updatePlayerClan = new UpdateChallengeResultCommand(playerId, challengeId, random.Next(100));
            await _sender.Send(updatePlayerClan);
        }

        #endregion

        #region PlayerCards


        for (int i = 0; i < playerIds.Count; i++)
        {
            playerCardsDict.Add(playerIds[i], new List<int>());

            for (int j = 0; j < 25; j++)
            {
                var cardId = random.Next(1, 110);

                var addPlayerCard = new AddCardCommand(playerIds[i], cardId);
                var result = await _sender.Send(addPlayerCard);
                    
                if (result.IsSuccess)
                    playerCardsDict[playerIds[i]].Add(cardId);
            }
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
                AmountTrophies = random.Next(10, 41),
                DurationInSeconds = random.Next(1, 180),
                LoserId = firstPlayer,
                WinnerId = secondPlayer
            };
            
            var battle = _mapper.Map<BattleModel>(battleRequest);
            var command = new AddBattleCommand(battle, battleRequest.WinnerId, battleRequest.LoserId);

            await _sender.Send(command);
        }

        #endregion

        #region War

        for (int i = 0; i < 3; i++)
        {
            var war = WarModel.Create(DateTime.Today);

            var command = new AddModelCommand<WarModel, int>(war);
            var result = await _sender.Send(command);

            if (result.IsFailure)
                continue;

            for (int j = 0; j < 3; j++)
            {
                int clanIdForWar = GetRandomFromArray(clanIds);
                int clanIdForWarIndex = playerIds.IndexOf(clanIdForWar);

                while (clanWarBooleanMask[clanIdForWarIndex])
                {
                    clanIdForWar = GetRandomFromArray(clanIds);
                    clanIdForWarIndex = playerIds.IndexOf(clanIdForWar);
                }


                var addclanWar = new AddClanWarCommand(clanIdForWar, result.Value, random.Next(10, 100));
                await _sender.Send(addclanWar);

                if(result.IsSuccess)
                    clanWarBooleanMask[clanIdForWarIndex] = true;
            }
        }

        #endregion

        #region Donations


        for (int i = 0; i < 10; i++)
        {
            var clanId = GetRandomFromArray(clanIds);

            while (playerClanDict[clanId].Count < 1)
                clanId = GetRandomFromArray(clanIds);

            for (int j = 0; j < 30; j++)
            {
                _context.ChangeTracker.Clear();
                var playerId = GetRandomFromArray(playerClanDict[clanId]);

                var cardId = GetRandomFromArray(playerCardsDict[playerId]);

                var date = new DateTime(random.Next(2010, 2023), random.Next(1, 13), random.Next(1, 28));

                var donation = new AddDonationCommand(playerId, clanId, cardId, random.Next(1, 8), date);

                await _sender.Send(donation);
            }
        }


        #endregion

        return Ok();
    }

    private static T GetRandomFromArray<T>(IReadOnlyList<T> array) => array[new Random().Next(array.Count)];
}