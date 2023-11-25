using AutoMapper;
using ClashRoyaleClanWarsAPI.API.Common.Mapping.Objects;
using ClashRoyaleClanWarsAPI.Application.Common.Commands.AddModel;
using ClashRoyaleClanWarsAPI.Application.Common.Commands.DeleteModel;
using ClashRoyaleClanWarsAPI.Application.Common.Commands.UpdateModel;
using ClashRoyaleClanWarsAPI.Application.Common.Queries.GetAllModel;
using ClashRoyaleClanWarsAPI.Application.Models.Player.Commands.AddCard;
using ClashRoyaleClanWarsAPI.Application.Models.Player.Commands.AddChallengePlayer;
using ClashRoyaleClanWarsAPI.Application.Models.Player.Commands.AddDonation;
using ClashRoyaleClanWarsAPI.Application.Models.Player.Commands.UpdateAlias;
using ClashRoyaleClanWarsAPI.Application.Models.Player.Commands.UpdateChallengeResult;
using ClashRoyaleClanWarsAPI.Application.Models.Player.Queries.GetAllCardOfPlayer;
using ClashRoyaleClanWarsAPI.Application.Models.Player.Queries.GetAllPlayerByAlias;
using ClashRoyaleClanWarsAPI.Application.Models.Player.Queries.GetPlayerByIdFullLoad;
using ClashRoyaleClanWarsAPI.Domain.Errors;
using ClashRoyaleClanWarsAPI.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ClashRoyaleClanWarsAPI.API.Controllers;
using ClashRoyaleClanWarsAPI.Domain.Shared;
using ClashRoyaleClanWarsAPI.Domain.Models.Card;

namespace ClashRoyaleClanWarsAPI.Tests
{
    public class PlayerControllerTest
    {
        private readonly PlayerController _sut;
        private readonly Mock<ISender> _sender = new Mock<ISender>();
        private readonly Mock<IMapper> _mapper = new Mock<IMapper>();
        private readonly Mock<PlayerModel> _player = new Mock<PlayerModel>();
        private readonly Error Error= new Error(ErrorCode.IdNotFound, "Id not found");

        public PlayerControllerTest()
        {
            _sut = new PlayerController(_sender.Object, _mapper.Object);
        }

        [Fact]
        public async Task GetAll_ShouldReturnOk()
        {
            //Arrange
            var query = new GetAllModelQuery<PlayerModel, int>();
            PlayerModel[] Players = new PlayerModel[2]
            {
                _player.Object, _player.Object
            };

            var result = Result.Success<IEnumerable<PlayerModel>>(Players);

            _sender.Setup(x => x.Send(query, default)).Returns(Task.FromResult(result));

            //Act
            var response = await _sut.GetAll();

            //Assert
            Assert.NotNull(response);
            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public async Task Get_ShouldReturnOk_WhenSuccess()
        {
            //Arrange
            int PlayerId = 1;
            var query = new GetPlayerByIdFullLoadQuery(PlayerId, true);
            var result = Result.Success<PlayerModel>(_player.Object);

            _sender.Setup(x => x.Send(query, default)).Returns(Task.FromResult(result));

            //Act
            var response = await _sut.Get(PlayerId);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public async Task Get_ShouldReturnProblem_WhenFailure()
        {
            //Arrange
            int PlayerId = 1;
            var query = new GetPlayerByIdFullLoadQuery(PlayerId, true);
            var result = Result.Failure<PlayerModel>(Error);

            _sender.Setup(x => x.Send(query, default)).Returns(Task.FromResult(result));

            //Act
            var response = await _sut.Get(PlayerId);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<NotFoundObjectResult>(response);
        }

        [Fact]
        public async Task GetAllByAlias_ShouldReturnOk_WhenSuccess()
        {
            //Arrange
            string PlayerAlias = "Dráckaro";
            var query = new GetAllPlayerByAliasQuery(PlayerAlias);
            PlayerModel[] Players = new PlayerModel[2]
            {
                _player.Object, _player.Object
            };

            var result = Result.Success<IEnumerable<PlayerModel>>(Players);

            _sender.Setup(x => x.Send(query, default)).Returns(Task.FromResult(result));

            //Act
            var response = await _sut.GetAllByAlias(PlayerAlias);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public async Task GetAllByAlias_ShouldReturnProblem_WhenFailure()
        {
            //Arrange
            string PlayerAlias = "Dráckaro";
            var query = new GetAllPlayerByAliasQuery(PlayerAlias);

            var result = Result.Failure<IEnumerable<PlayerModel>>(Error);

            _sender.Setup(x => x.Send(query, default)).Returns(Task.FromResult(result));

            //Act
            var response = await _sut.GetAllByAlias(PlayerAlias);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<NotFoundObjectResult>(response);
        }

        [Fact]
        public async Task Post_ShouldReturnCreated_WhenSuccess()
        {
            //Arrange
            var PlayerRequest = new AddPlayerRequest();
            var player = _mapper.Object.Map<PlayerModel>(PlayerRequest);
            var command = new AddModelCommand<PlayerModel, int>(player);
            var result = Result.Success<int>(1);

            _sender.Setup(x => x.Send(command, default)).Returns(Task.FromResult(result));

            //Act
            var response = await _sut.Post(PlayerRequest);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<CreatedResult>(response);
        }

        [Fact]
        public async Task Post_ShouldReturnProblem_WhenFailure()
        {
            //Arrange
            var PlayerRequest = new AddPlayerRequest();
            var player = _mapper.Object.Map<PlayerModel>(PlayerRequest);
            var command = new AddModelCommand<PlayerModel, int>(player);
            var result = Result.Failure<int>(Error);

            _sender.Setup(x => x.Send(command, default)).Returns(Task.FromResult(result));

            //Act
            var response = await _sut.Post(PlayerRequest);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<NotFoundObjectResult>(response);
        }

        [Fact]
        public async Task Put_ShouldReturnNoContent_WhenSuccess()
        {
            //Arrange
            int PlayerId = 1;
            var PlayerRequest = new UpdatePlayerRequest()
            {
                Id = 1
            };
            var player = _mapper.Object.Map<PlayerModel>(PlayerRequest);
            var command = new UpdateModelCommand<PlayerModel, int>(player);
            var result = Result.Success();

            _sender.Setup(x => x.Send(command, default)).Returns(Task.FromResult(result));

            //Act
            var response = await _sut.Put(PlayerId, PlayerRequest);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<NoContentResult>(response);
        }

        [Fact]
        public async Task Put_ShouldReturnProblem_WhenFailure()
        {
            //Arrange
            int PlayerId = 1;
            var PlayerRequest = new UpdatePlayerRequest()
            {
                Id = 1
            };
            var player = _mapper.Object.Map<PlayerModel>(PlayerRequest);
            var command = new UpdateModelCommand<PlayerModel, int>(player);
            var result = Result.Failure(Error);

            _sender.Setup(x => x.Send(command, default)).Returns(Task.FromResult(result));

            //Act
            var response = await _sut.Put(PlayerId, PlayerRequest);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<NotFoundObjectResult>(response);
        }

        [Fact]
        public async Task Put_ShouldReturnError_WhenDifferentIds()
        {
            //Arrange
            int PlayerId = 1;
            var PlayerRequest = new UpdatePlayerRequest()
            {
                Id = 2
            };

            //Act
            var response = await _sut.Put(PlayerId, PlayerRequest);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<BadRequestObjectResult>(response);
        }

        [Fact]
        public async Task Delete_ShouldReturnNoContent_WhenSuccess()
        {
            //Arrange
            int PlayerId = 1;
            var commandDelete = new DeleteModelCommand<PlayerModel, int>(PlayerId);
            var result = Result.Success();

            _sender.Setup(x => x.Send(commandDelete, default)).Returns(Task.FromResult(result));

            //Act
            var response = await _sut.Delete(PlayerId);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<NoContentResult>(response);
        }

        [Fact]
        public async Task Delete_ShouldReturnProblem_WhenFailure()
        {
            //Arrange
            int PlayerId = 1;
            var commandDelete = new DeleteModelCommand<PlayerModel, int>(PlayerId);
            var result = Result.Failure(Error);

            _sender.Setup(x => x.Send(commandDelete, default)).Returns(Task.FromResult(result));

            //Act
            var response = await _sut.Delete(PlayerId);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<NotFoundObjectResult>(response);
        }

        [Fact]
        public async Task GetCards_ShouldReturnOk_WhenSuccess()
        {
            //Arrange
            int PlayerId = 1;
            var query = new GetAllCardOfPlayerQuery(PlayerId);
            Mock<CardModel> _cards = new Mock<CardModel>();
            CardModel[] Cards = new CardModel[2]
            {
                _cards.Object, _cards.Object
            };
            var result = Result.Success<IEnumerable<CardModel>>(Cards);

            _sender.Setup(x => x.Send(query, default)).Returns(Task.FromResult(result));

            //Act
            var response = await _sut.GetCards(PlayerId);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public async Task GetCards_ShouldReturnProblem_WhenFailure()
        {
            //Arrange
            int PlayerId = 1;
            var query = new GetAllCardOfPlayerQuery(PlayerId);
            var result = Result.Failure<IEnumerable<CardModel>>(Error);

            _sender.Setup(x => x.Send(query, default)).Returns(Task.FromResult(result));

            //Act
            var response = await _sut.GetCards(PlayerId);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<NotFoundObjectResult>(response);
        }

        [Fact]
        public async Task AddCard_ShouldReturnOk_WhenSuccess()
        {
            //Arrange
            int PlayerId = 1;
            int CardId = 1;
            var command = new AddCardCommand(PlayerId, CardId);
            var result = Result.Success();

            _sender.Setup(x => x.Send(command, default)).Returns(Task.FromResult(result));

            //Act
            var response = await _sut.AddCard(PlayerId, CardId);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<OkResult>(response);
        }

        [Fact]
        public async Task AddCard_ShouldReturnProblem_WhenFailure()
        {
            //Arrange
            int PlayerId = 1;
            int CardId = 1;
            var command = new AddCardCommand(PlayerId, CardId);
            var result = Result.Failure(Error);

            _sender.Setup(x => x.Send(command, default)).Returns(Task.FromResult(result));

            //Act
            var response = await _sut.AddCard(PlayerId, CardId);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<NotFoundObjectResult>(response);
        }

        [Fact]
        public async Task UpdateAlias_ShouldReturnOk_WhenSuccess()
        {
            //Arrange
            int PlayerId = 1;
            string Alias = "Dráckaro";
            var query = new UpdatePlayerAliasCommand(PlayerId, Alias);
            var result = Result.Success();

            _sender.Setup(x => x.Send(query, default)).Returns(Task.FromResult(result));

            //Act
            var response = await _sut.UpdateAlias(PlayerId, Alias);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<OkResult>(response);
        }

        [Fact]
        public async Task UpdateAlias_ShouldReturnProblem_WhenFailure()
        {
            //Arrange
            int PlayerId = 1;
            string Alias = "Dráckaro";
            var query = new UpdatePlayerAliasCommand(PlayerId, Alias);
            var result = Result.Failure(Error);

            _sender.Setup(x => x.Send(query, default)).Returns(Task.FromResult(result));

            //Act
            var response = await _sut.UpdateAlias(PlayerId, Alias);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<NotFoundObjectResult>(response);
        }

        [Fact]
        public async Task UpdateChallengeResult_ShouldReturnNoContent_WhenSuccess()
        {
            //Arrange
            int PlayerId = 1;
            int ChallengeId = 1;
            var AddChallengeResult = new AddChallengeResultRequest();
            var command = new UpdateChallengeResultCommand(PlayerId, ChallengeId, AddChallengeResult.Reward);
            var result = Result.Success();

            _sender.Setup(x => x.Send(command, default)).Returns(Task.FromResult(result));

            //Act
            var response = await _sut.UpdateChallengeResult(PlayerId, ChallengeId, AddChallengeResult);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<NoContentResult>(response);
        }

        [Fact]
        public async Task UpdateChallengeResult_ShouldReturnProblem_WhenFailure()
        {
            //Arrange
            int PlayerId = 1;
            int ChallengeId = 1;
            var AddChallengeResult = new AddChallengeResultRequest();
            var command = new UpdateChallengeResultCommand(PlayerId, ChallengeId, AddChallengeResult.Reward);
            var result = Result.Failure(Error);

            _sender.Setup(x => x.Send(command, default)).Returns(Task.FromResult(result));

            //Act
            var response = await _sut.UpdateChallengeResult(PlayerId, ChallengeId, AddChallengeResult);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<NotFoundObjectResult>(response);
        }

        [Fact]
        public async Task PostPlayerChallenge_ShouldReturnNoContent_WhenSuccess()
        {
            //Arrange
            int PlayerId = 1;
            int ChallengeId = 1;
            var AddChallengeResult = new AddChallengeResultRequest();
            var command = new AddChallengePlayerCommand(PlayerId, ChallengeId, AddChallengeResult.Reward);
            var result = Result.Success();

            _sender.Setup(x => x.Send(command, default)).Returns(Task.FromResult(result));

            //Act
            var response = await _sut.PostPlayerChallenge(PlayerId, ChallengeId, AddChallengeResult);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<NoContentResult>(response);
        }

        [Fact]
        public async Task PostPlayerChallenge_ShouldReturnProblem_WhenFailure()
        {
            //Arrange
            int PlayerId = 1;
            int ChallengeId = 1;
            var AddChallengeResult = new AddChallengeResultRequest();
            var command = new AddChallengePlayerCommand(PlayerId, ChallengeId, AddChallengeResult.Reward);
            var result = Result.Failure(Error);

            _sender.Setup(x => x.Send(command, default)).Returns(Task.FromResult(result));

            //Act
            var response = await _sut.PostPlayerChallenge(PlayerId, ChallengeId, AddChallengeResult);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<NotFoundObjectResult>(response);
        }

        [Fact]
        public async Task MakeDonation_ShouldReturnNoContent_WhenSuccess()
        {
            //Arrange
            int PlayerId = 1;
            var AddDonation = new AddDonationRequest();
            var result = Result.Success();

            _sender.Setup(x => x.Send(It.IsAny<AddDonationCommand>(), default)).Returns(Task.FromResult(result));

            //Act
            var response = await _sut.MakeDonation(PlayerId, AddDonation);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<NoContentResult>(response);
        }

        [Fact]
        public async Task MakeDonation_ShouldReturnProblem_WhenFailure()
        {
            //Arrange
            int PlayerId = 1;
            var AddDonation = new AddDonationRequest();
            var result = Result.Failure(Error);

            _sender.Setup(x => x.Send(It.IsAny<AddDonationCommand>(), default)).Returns(Task.FromResult(result));

            //Act
            var response = await _sut.MakeDonation(PlayerId, AddDonation);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<NotFoundObjectResult>(response);
        }
    }
}