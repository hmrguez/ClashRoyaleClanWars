using Moq;
using ClashRoyaleClanWarsAPI.API.Controllers;
using AutoMapper;
using ClashRoyaleClanWarsAPI.API.Common.Mapping.Objects;
using ClashRoyaleClanWarsAPI.Application.Models.Battle.Command.AddBattle;
using ClashRoyaleClanWarsAPI.Application.Models.Battle.Queries.GetAllBattleInclude;
using ClashRoyaleClanWarsAPI.Application.Models.Battle.Queries.GetBattleByIdFullLoad;
using ClashRoyaleClanWarsAPI.Domain.Models.Battle;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ClashRoyaleClanWarsAPI.Domain.Shared;
using ClashRoyaleClanWarsAPI.Domain.Models;


namespace ClashRoyaleClanWarsAPI.Tests
{
    public class BattleControllerTest
    {
        private readonly BattleController _sut;
        private readonly Mock<ISender> _sender = new Mock<ISender>();
        private readonly Mock<IMapper> _mapper = new Mock<IMapper>();
        private readonly PlayerModel _player = PlayerModel.Create("Dráckaro");

        public BattleControllerTest()
        {
            _sut = new BattleController(_sender.Object, _mapper.Object);
        }

        [Fact]
        public async Task GetAll_ShouldReturnOk_WhenSuccess()
        {
            //Arrange
            var query = new GetAllBattleIncludeQuery();

            var battle1 = BattleModel.Create(30, _player, _player, 180, DateTime.Now);
            var battle2 = BattleModel.Create(28, _player, _player, 180, DateTime.Now);

            BattleModel[] Battles = new BattleModel[2]
            {
                battle1, battle2
            };

            var result = Result.Success<IEnumerable<BattleModel>>(Battles);

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
            var query = new GetAllBattleIncludeQuery();

            var result = Result.Failure<IEnumerable<BattleModel>>(new Error("Model.IdNotFound","Model.IdNotFound"));

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
            var BattleId = new Guid();
            var query = new GetBattleByIdFullLoadQuery(BattleId, true);
            var battle = BattleModel.Create(30, _player, _player, 180, DateTime.Now);
            var result = Result.Success<BattleModel>(battle);

            _sender.Setup(x => x.Send(query, default)).Returns(Task.FromResult(result));

            //Act
            var response = await _sut.Get(BattleId);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<OkObjectResult>(response);
        }

         [Fact]
        public async Task Get_ShouldReturnProblem_WhenFailure()
        {
            //Arrange
            var BattleId = new Guid();
            var query = new GetBattleByIdFullLoadQuery(BattleId, true);
            var result = Result.Failure<BattleModel>(new Error("Model.IdNotFound","Model.IdNotFound"));

            _sender.Setup(x => x.Send(query, default)).Returns(Task.FromResult(result));

            //Act
            var response = await _sut.Get(BattleId);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<NotFoundObjectResult>(response);
        }

        [Fact]
        public async Task Post_ShouldReturnCreated_WhenSuccess()
        {
            //Arrange
            var BattleRequest = new AddBattleRequest()
            {
                WinnerId = 1,
                LoserId = 2
            };

            var battle = _mapper.Object.Map<BattleModel>(BattleRequest);
            var command = new AddBattleCommand(battle, BattleRequest.WinnerId, BattleRequest.LoserId);
            var result = Result.Success<Guid>(new Guid());

            _sender.Setup(x => x.Send(command, default)).Returns(Task.FromResult(result));

            //Act
            var response = await _sut.Post(BattleRequest);
            
            //Assert
            Assert.NotNull(response);
            Assert.IsType<CreatedResult>(response);
        }

        [Fact]
        public async Task Post_ShouldReturnProblem_WhenFailure()
        {
            //Arrange
            var BattleRequest = new AddBattleRequest()
            {
                WinnerId = 1,
                LoserId = 2
            };

            var battle = _mapper.Object.Map<BattleModel>(BattleRequest);
            var command = new AddBattleCommand(battle, BattleRequest.WinnerId, BattleRequest.LoserId);
            var result = Result.Failure<Guid>(new Error("Model.IdNotFound","Model.IdNotFound"));

            _sender.Setup(x => x.Send(command, default)).Returns(Task.FromResult(result));

            //Act
            var response = await _sut.Post(BattleRequest);
            
            //Assert
            Assert.NotNull(response);
            Assert.IsType<NotFoundObjectResult>(response);
        }
    }
}