using AutoMapper;
using ClashRoyaleClanWarsAPI.API.Common.Mapping.Objects;
using ClashRoyaleClanWarsAPI.Application.Common.Commands.DeleteModel;
using ClashRoyaleClanWarsAPI.Application.Common.Commands.UpdateModel;
using ClashRoyaleClanWarsAPI.Application.Common.Queries.GetAllModel;
using ClashRoyaleClanWarsAPI.Application.Models.Clan.Commands.AddClanWithCreator;
using ClashRoyaleClanWarsAPI.Application.Models.Clan.Commands.AddPlayerClan;
using ClashRoyaleClanWarsAPI.Application.Models.Clan.Commands.RemovePlayerClan;
using ClashRoyaleClanWarsAPI.Application.Models.Clan.Commands.UpdatePlayerRank;
using ClashRoyaleClanWarsAPI.Application.Models.Clan.Queries.GetAllClanByName;
using ClashRoyaleClanWarsAPI.Application.Models.Clan.Queries.GetAllPlayers;
using ClashRoyaleClanWarsAPI.Application.Models.Clan.Queries.GetClanAvailables;
using ClashRoyaleClanWarsAPI.Application.Models.Clan.Queries.GetClanByIdFullLoad;
using ClashRoyaleClanWarsAPI.Domain.Enum;
using ClashRoyaleClanWarsAPI.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ClashRoyaleClanWarsAPI.API.Controllers;
using ClashRoyaleClanWarsAPI.Domain.Shared;
using ClashRoyaleClanWarsAPI.Domain.Relationships;

namespace ClashRoyaleClanWarsAPI.Tests
{
    public class ClanControllerTest
    {
        private readonly ClanController _sut;
        private readonly Mock<ISender> _sender = new Mock<ISender>();
        private readonly Mock<IMapper> _mapper = new Mock<IMapper>();
        private readonly Mock<ClanModel> _clan = new Mock<ClanModel>();

        public ClanControllerTest()
        {
            _sut = new ClanController(_sender.Object, _mapper.Object);
        }

        [Fact]
        public async Task GetAll_ShouldReturnOk_WhenSuccess()
        {
            //Arrange
            var query = new GetAllModelQuery<ClanModel, int>();

            ClanModel[] Clans = new ClanModel[2]
            {
                _clan.Object, _clan.Object
            };

            var result = Result.Success<IEnumerable<ClanModel>>(Clans);

            _sender.Setup(x => x.Send(query, default)).Returns(Task.FromResult(result));

            //Act
            var response = await _sut.GetAll();

            //Assert
            Assert.NotNull(response);
            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public async Task GetAll_ShouldReturnProblem_WhenFailure()
        {
            //Arrange
            var query = new GetAllModelQuery<ClanModel, int>();
            var result = Result.Failure<IEnumerable<ClanModel>>(new Error("Model.ModelNotFound","Model.ModelNotFound"));

            _sender.Setup(x => x.Send(query, default)).Returns(Task.FromResult(result));

            //Act
            var response = await _sut.GetAll();

            //Assert
            Assert.NotNull(response);
            Assert.IsType<NotFoundObjectResult>(response);
        }

        [Fact]
        public async Task Get_ShouldReturnOk_WhenSuccess()
        {
            //Arrange
            int ClanId = 1;
            var query = new GetClanByIdFullLoadQuery(ClanId, true);
            var result = Result.Success<ClanModel>(_clan.Object);

            _sender.Setup(x => x.Send(query, default)).Returns(Task.FromResult(result));

            //Act
            var response = await _sut.Get(ClanId);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public async Task Get_ShouldReturnProblem_WhenFailure()
        {
            //Arrange
            int ClanId = 1;
            var query = new GetClanByIdFullLoadQuery(ClanId, true);
            var result = Result.Failure<ClanModel>(new Error("Model.ModelNotFound","Model.ModelNotFound"));

            _sender.Setup(x => x.Send(query, default)).Returns(Task.FromResult(result));

            //Act
            var response = await _sut.Get(ClanId);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<NotFoundObjectResult>(response);
        }

        [Fact]
        public async Task Post_ShouldReturnCreated_WhenSuccess()
        {
            //Arrange
            int PlayerId = 1;
            var ClanRequest = new AddClanRequest();
            var clan = _mapper.Object.Map<ClanModel>(ClanRequest);
            var command = new AddClanWithCreatorCommand(PlayerId, clan);
            var result = Result.Success<int>(PlayerId);

            _sender.Setup(x => x.Send(command, default)).Returns(Task.FromResult(result));

            //Act
            var response = await _sut.Post(PlayerId, ClanRequest);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<CreatedResult>(response);
        }

        [Fact]
        public async Task Post_ShouldReturnProblem_WhenFailure()
        {
            //Arrange
            int PlayerId = 1;
            var ClanRequest = new AddClanRequest();
            var clan = _mapper.Object.Map<ClanModel>(ClanRequest);
            var command = new AddClanWithCreatorCommand(PlayerId, clan);
            var result = Result.Failure<int>(new Error("Model.ModelNotFound","Model.ModelNotFound"));

            _sender.Setup(x => x.Send(command, default)).Returns(Task.FromResult(result));

            //Act
            var response = await _sut.Post(PlayerId, ClanRequest);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<NotFoundObjectResult>(response);
        }

        [Fact]
        public async Task Put_ShouldReturnNoContent_WhenSuccess()
        {
            //Arrange
            int ClanId = 1;
            var ClanRequest = new UpdateClanRequest()
            {
                Id = 1
            };

            var clan = _mapper.Object.Map<ClanModel>(ClanRequest);
            var command = new UpdateModelCommand<ClanModel, int>(clan);
            var result = Result.Success();

            _sender.Setup(x => x.Send(command, default)).Returns(Task.FromResult(result));

            //Act
            var response = await _sut.Put(ClanId, ClanRequest);
            //Assert
            Assert.NotNull(response);
            Assert.IsType<NoContentResult>(response);
        }

        [Fact]
        public async Task Put_ShouldReturnProblem_WhenFailure()
        {
            //Arrange
            int ClanId = 1;
            var ClanRequest = new UpdateClanRequest()
            {
                Id = 1
            };

            var clan = _mapper.Object.Map<ClanModel>(ClanRequest);
            var command = new UpdateModelCommand<ClanModel, int>(clan);
            var result = Result.Failure(new Error("Model.ModelNotFound","Model.ModelNotFound"));

            _sender.Setup(x => x.Send(command, default)).Returns(Task.FromResult(result));

            //Act
            var response = await _sut.Put(ClanId, ClanRequest);
            //Assert
            Assert.NotNull(response);
            Assert.IsType<NotFoundObjectResult>(response);
        }

        [Fact]
        public async Task Put_ShouldReturnError_WhenDifferentsIds()
        {
            //Arrange
            int ClanId = 1;
            var ClanRequest = new UpdateClanRequest()
            {
                Id = 2
            };

            //Act
            var response = await _sut.Put(ClanId, ClanRequest);
            //Assert
            Assert.NotNull(response);
            Assert.IsType<BadRequestObjectResult>(response);
        }

        [Fact]
        public async Task Delete_ShouldReturnNoContent_WhenSuccess()
        {
            //Arrange
            int ClanId = 1;
            var command = new DeleteModelCommand<ClanModel, int>(ClanId);
            var result = Result.Success();

            _sender.Setup(x => x.Send(command, default)).Returns(Task.FromResult(result));

            //Act
            var response = await _sut.Delete(ClanId);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<NoContentResult>(response);
        }

        [Fact]
        public async Task Delete_ShouldReturnProblem_WhenFailure()
        {
            //Arrange
            int ClanId = 1;
            var command = new DeleteModelCommand<ClanModel, int>(ClanId);
            var result = Result.Failure(new Error("Model.ModelNotFound","Model.ModelNotFound"));

            _sender.Setup(x => x.Send(command, default)).Returns(Task.FromResult(result));

            //Act
            var response = await _sut.Delete(ClanId);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<NotFoundObjectResult>(response);
        }

        [Fact]
        public async Task GetClansAvailable_ShouldReturnOk_WhenSuccess()
        {
            //Arrange
            int Trophies = 500;
            var query = new GetClanAvailablesQuery(Trophies);
            ClanModel[] Clans = new ClanModel[2]
            {
                _clan.Object, _clan.Object
            };

            var result = Result.Success<IEnumerable<ClanModel>>(Clans);

            _sender.Setup(x => x.Send(query, default)).Returns(Task.FromResult(result));

            //Act
            var response = await _sut.GetClanAvailables(Trophies);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public async Task GetClansAvailable_ShouldReturnProblem_WhenFailure()
        {
            //Arrange
            int Trophies = 500;
            var query = new GetClanAvailablesQuery(Trophies);

            var result = Result.Failure<IEnumerable<ClanModel>>(new Error("Model.ModelNotFound","Model.ModelNotFound"));

            _sender.Setup(x => x.Send(query, default)).Returns(Task.FromResult(result));

            //Act
            var response = await _sut.GetClanAvailables(Trophies);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<NotFoundObjectResult>(response);
        }

        [Fact]
        public async Task GetClansByName_ShouldReturnOk_WhenSuccess()
        {
            //Arrange
            string ClanName = "Los Piedras";
            var query = new GetAllClanByNameQuery(ClanName);
            ClanModel[] Clans = new ClanModel[2]
            {
                _clan.Object, _clan.Object
            };

            var result = Result.Success<IEnumerable<ClanModel>>(Clans);

            _sender.Setup(x => x.Send(query, default)).Returns(Task.FromResult(result));

            //Act
            var response = await _sut.GetClansByName(ClanName);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public async Task GetClansByName_ShouldReturnProblem_WhenFailuer()
        {
            //Arrange
            string ClanName = "Los Piedras";
            var query = new GetAllClanByNameQuery(ClanName);

            var result = Result.Failure<IEnumerable<ClanModel>>(new Error("Model.ModelNotFound","Model.ModelNotFound"));

            _sender.Setup(x => x.Send(query, default)).Returns(Task.FromResult(result));

            //Act
            var response = await _sut.GetClansByName(ClanName);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<NotFoundObjectResult>(response);
        }

        [Fact]
        public async Task GetPlayers_ShouldReturnOk_WhenSuccess()
        {
            //Arrange
            int ClanId = 1;
            var query = new GetAllPlayersQuery(ClanId);
            Mock<PlayerModel> _player = new Mock<PlayerModel>();
            var Player1 = ClanPlayersModel.Create(_player.Object, _clan.Object, RankClan.Leader);
            var Player2 = ClanPlayersModel.Create(_player.Object, _clan.Object, RankClan.Member);

            ClanPlayersModel[] Players = new ClanPlayersModel[2]
            {
                Player1, Player2
            };

            var result = Result.Success<IEnumerable<ClanPlayersModel>>(Players);

            _sender.Setup(x => x.Send(query, default)).Returns(Task.FromResult(result));

            //Act
            var response = await _sut.GetPlayers(ClanId);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public async Task GetPlayers_ShouldReturnProblem_WhenFailure()
        {
            //Arrange
            int ClanId = 1;
            var query = new GetAllPlayersQuery(ClanId);

            var result = Result.Failure<IEnumerable<ClanPlayersModel>>(new Error("Model.ModelNotFound","Model.ModelNotFound"));

            _sender.Setup(x => x.Send(query, default)).Returns(Task.FromResult(result));

            //Act
            var response = await _sut.GetPlayers(ClanId);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<NotFoundObjectResult>(response);
        }

        [Fact]
        public async Task AddPlayer_ShouldReturnNoContent_WhenSuccess()
        {
            //Arrange
            int ClanId = 1;
            int PlayerId = 10;
            var command = new AddPlayerClanCommand(ClanId, PlayerId);
            var result = Result.Success();

            _sender.Setup(x => x.Send(command, default)).Returns(Task.FromResult(result));

            //Act
            var response = await _sut.AddPlayer(ClanId, PlayerId);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<NoContentResult>(response);
        }

        [Fact]
        public async Task AddPlayer_ShouldReturnProblem_WhenFailure()
        {
            //Arrange
            int ClanId = 1;
            int PlayerId = 10;
            var command = new AddPlayerClanCommand(ClanId, PlayerId);
            var result = Result.Failure(new Error("Model.ModelNotFound","Model.ModelNotFound"));

            _sender.Setup(x => x.Send(command, default)).Returns(Task.FromResult(result));

            //Act
            var response = await _sut.AddPlayer(ClanId, PlayerId);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<NotFoundObjectResult>(response);
        }

        [Fact]
        public async Task RemovePlayer_ShouldReturnNoContent_WhenSuccess()
        {
            //Arrange
            int ClanId = 1;
            int PlayerId = 10;
            var command = new RemovePlayerClanCommand(ClanId, PlayerId);
            var result = Result.Success();

            _sender.Setup(x => x.Send(command, default)).Returns(Task.FromResult(result));

            //Act
            var response = await _sut.RemovePlayer(ClanId, PlayerId);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<NoContentResult>(response);
        }

        [Fact]
        public async Task RemovePlayer_ShouldReturnProblem_WhenFailure()
        {
            //Arrange
            int ClanId = 1;
            int PlayerId = 10;
            var command = new RemovePlayerClanCommand(ClanId, PlayerId);
            var result = Result.Failure(new Error("Model.ModelNotFound","Model.ModelNotFound"));

            _sender.Setup(x => x.Send(command, default)).Returns(Task.FromResult(result));

            //Act
            var response = await _sut.RemovePlayer(ClanId, PlayerId);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<NotFoundObjectResult>(response);
        }

        [Fact]
        public async Task UpdatePlayerRank_ShouldReturnNoContent_WhenSuccess()
        {
            //Arrange
            int ClanId = 1;
            int PlayerId = 10;
            RankClan Rank = RankClan.Leader;
            var command = new UpdatePlayerRankCommand(ClanId, PlayerId, Rank);
            var result = Result.Success();

            _sender.Setup(x => x.Send(command, default)).Returns(Task.FromResult(result));

            //Act
            var response = await _sut.UpdatePlayerRank(ClanId, PlayerId, Rank);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<NoContentResult>(response);
        }

        [Fact]
        public async Task UpdatePlayerRank_ShouldReturnProblem_WhenFailure()
        {
            //Arrange
            int ClanId = 1;
            int PlayerId = 10;
            RankClan Rank = RankClan.Leader;
            var command = new UpdatePlayerRankCommand(ClanId, PlayerId, Rank);
            var result = Result.Failure(new Error("Model.ModelNotFound","Model.ModelNotFound"));

            _sender.Setup(x => x.Send(command, default)).Returns(Task.FromResult(result));

            //Act
            var response = await _sut.UpdatePlayerRank(ClanId, PlayerId, Rank);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<NotFoundObjectResult>(response);
        }
    }
}