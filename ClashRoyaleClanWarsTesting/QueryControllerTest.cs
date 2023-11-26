using ClashRoyaleClanWarsAPI.API.Controllers;
using ClashRoyaleClanWarsAPI.Application.Common.Queries.GetModelById;
using ClashRoyaleClanWarsAPI.Application.Interfaces;
using ClashRoyaleClanWarsAPI.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ClashRoyaleClanWarsAPI.Domain.Shared;
using ClashRoyaleClanWarsAPI.Application.Responses;
using ClashRoyaleClanWarsAPI.Domain.Errors;

namespace ClashRoyaleClanWarsAPI.Tests
{
    public class QueryControllerTest
    {
        private readonly  QueryController _sut;
        private readonly Mock<IMediator> _sender = new Mock<IMediator>();
        private readonly Mock<IPredefinedQueries> _querys = new Mock<IPredefinedQueries>();

        public QueryControllerTest()
        {
            _sut = new QueryController(_sender.Object, _querys.Object);
        }

        [Fact]
        public async Task GetFirstQuery_ShouldReturnOk()
        {
            //Arrange
            _querys.Setup(x => x.FirstQuery())
                .Returns(Task.FromResult(It.IsAny<IEnumerable<FirstQueryResponse>>()));

            //Act
            var response = await _sut.GetFirstQuery();

            //Assert
            Assert.NotNull(response);
            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public async Task GetSecondQuery_ShouldReturnOk()
        {
            //Arrange
            _querys.Setup(x => x.SecondQuery())
                .Returns(Task.FromResult(It.IsAny<IEnumerable<SecondQueryResponse>>()));

            //Act
            var response = await _sut.GetSecondQuery();

            //Assert
            Assert.NotNull(response);
            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public async Task GetThirdQuery_ShouldReturnOk()
        {
            //Arrange
            _querys.Setup(x => x.ThirdQuery())
                .Returns(Task.FromResult(It.IsAny<IEnumerable<ThirdQueryResponse>>()));

            //Act
            var response = await _sut.GetThirdQuery();

            //Assert
            Assert.NotNull(response);
            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public async Task GetFourthQuery_ShouldReturnOk()
        {
            //Arrange
            _querys.Setup(x => x.FourthQuery())
                .Returns(Task.FromResult(It.IsAny<IEnumerable<FourthQueryResponse>>()));

            //Act
            var response = await _sut.GetFourthQuery();

            //Assert
            Assert.NotNull(response);
            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public async Task GetFifthQuery_ShouldReturnOk_WhenSuccess()
        {
            //Arrange
            var Player = new PlayerModel();
            Player.UpdateElo(3000);
            var result = Result.Success(Player);

            _sender.Setup(x => x.Send(It.IsAny<GetModelByIdQuery<PlayerModel, int>>(), default))
                .Returns(Task.FromResult(result));

            _querys.Setup(x => x.FifthQuery(It.IsAny<int>()))
                .Returns(Task.FromResult(It.IsAny<IEnumerable<FifthQueryResponse>>()));

            //Act
            var response = await _sut.GetFifthQuery(1);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public async Task GetFifthQuery_ShouldReturnProblem_WhenFailure()
        {
            //Arrange
            var result = Result.Failure<PlayerModel>(new Error(ErrorCode.IdNotFound, "Id not found"));

            _sender.Setup(x => x.Send(It.IsAny<GetModelByIdQuery<PlayerModel, int>>(), default))
                .Returns(Task.FromResult(result));

            //Act
            var response = await _sut.GetFifthQuery(1);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<NotFoundObjectResult>(response);
        }

        [Fact]
        public async Task GetSixthQuery_ShouldReturnOk()
        {
            //Arrange
            _querys.Setup(x => x.SixthQuery())
                .Returns(Task.FromResult(It.IsAny<IEnumerable<SixthQueryResponse>>()));

            //Act
            var response = await _sut.GetSixthQuery();

            //Assert
            Assert.NotNull(response);
            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public async Task GetSeventhQuery_ShouldReturnOk()
        {
            //Arrange
            _querys.Setup(x => x.SeventhQuery(It.IsAny<int>()))
                .Returns(Task.FromResult(It.IsAny<IEnumerable<SeventhQueryResponse>>()));

            //Act
            var response = await _sut.GetSeventhQuery(2023);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<OkObjectResult>(response);
        }
    }
        
}