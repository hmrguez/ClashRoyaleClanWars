using AutoMapper;
using ClashRoyaleClanWarsAPI.API.Common.Mapping.Objects;
using ClashRoyaleClanWarsAPI.Application.Common.Commands.AddModel;
using ClashRoyaleClanWarsAPI.Application.Common.Commands.DeleteModel;
using ClashRoyaleClanWarsAPI.Application.Common.Queries.GetAllModel;
using ClashRoyaleClanWarsAPI.Application.Common.Queries.GetModelById;
using ClashRoyaleClanWarsAPI.Application.Models.War.Commands.AddClanWar;
using ClashRoyaleClanWarsAPI.Application.Models.War.Queries.GetUpCommingWars;
using ClashRoyaleClanWarsAPI.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ClashRoyaleClanWarsAPI.Domain.Errors;
using Moq;
using ClashRoyaleClanWarsAPI.API.Controllers;
using ClashRoyaleClanWarsAPI.Domain.Shared;

namespace ClashRoyaleClanWarsAPI.Tests
{
    public class WarControllerTest
    {
        private readonly WarController _sut;
        private readonly Mock<ISender> _sender = new Mock<ISender>();
        private readonly Mock<IMapper> _mapper = new Mock<IMapper>();
        private readonly Error Error = new Error(ErrorCode.IdNotFound, "Id not found");

        public WarControllerTest()
        {
            _sut = new WarController(_sender.Object, _mapper.Object);
        }

        [Fact]
        public async Task GetAll_ShouldReturnOk_WhenSuccess()
        {
            //Arrange
            var result = Result.Success(It.IsAny<IEnumerable<WarModel>>());

            _sender.Setup(x => x.Send(It.IsAny<GetAllModelQuery<WarModel, int>>(), default))
                .Returns(Task.FromResult(result));

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
            var result = Result.Failure<IEnumerable<WarModel>>(Error);

            _sender.Setup(x => x.Send(It.IsAny<GetAllModelQuery<WarModel, int>>(), default))
                .Returns(Task.FromResult(result));

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
            var result = Result.Success(It.IsAny<WarModel>());

            _sender.Setup(x => x.Send(It.IsAny<GetModelByIdQuery<WarModel, int>>(), default))
                .Returns(Task.FromResult(result));

            //Act
            var response = await _sut.Get(1);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public async Task Get_ShouldReturnProblem_WhenFailure()
        {
            //Arrange
            var result = Result.Failure<WarModel>(Error);

            _sender.Setup(x => x.Send(It.IsAny<GetModelByIdQuery<WarModel, int>>(), default))
                .Returns(Task.FromResult(result));

            //Act
            var response = await _sut.Get(1);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<NotFoundObjectResult>(response);
        }

        [Fact]
        public async Task Post_ShouldReturnCreated_WhenSuccess()
        {
            //Arrange
            var result = Result.Success<int>(1);

            _sender.Setup(x => x.Send(It.IsAny<AddModelCommand<WarModel, int>>(), default))
                .Returns(Task.FromResult(result));

            //Act
            var response = await _sut.Post(new AddWarRequest());

            //Assert
            Assert.NotNull(response);
            Assert.IsType<CreatedResult>(response);
        }

        [Fact]
        public async Task Post_ShouldReturnProblem_WhenFailure()
        {
            //Arrange
            var result = Result.Failure<int>(Error);

            _sender.Setup(x => x.Send(It.IsAny<AddModelCommand<WarModel, int>>(), default))
                .Returns(Task.FromResult(result));

            //Act
            var response = await _sut.Post(new AddWarRequest());

            //Assert
            Assert.NotNull(response);
            Assert.IsType<NotFoundObjectResult>(response);
        }

        [Fact]
        public async Task Delete_ShouldReturnNoContent_WhenSuccess()
        {
            //Arrange
            var result = Result.Success();

            _sender.Setup(x => x.Send(It.IsAny<DeleteModelCommand<WarModel, int>>(), default))
                .Returns(Task.FromResult(result));

            //Act
            var response = await _sut.Delete(1);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<NoContentResult>(response);
        }

        [Fact]
        public async Task Delete_ShouldReturnProblem_WhenFailure()
        {
            //Arrange
            var result = Result.Failure(Error);

            _sender.Setup(x => x.Send(It.IsAny<DeleteModelCommand<WarModel, int>>(), default))
                .Returns(Task.FromResult(result));

            //Act
            var response = await _sut.Delete(1);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<NotFoundObjectResult>(response);
        }

        [Fact]
        public async Task GetUpCommingWars_ShouldReturnOk_WhenSuccess()
        {
            //Arrange
            var result = Result.Success(It.IsAny<IEnumerable<WarModel>>());

            _sender.Setup(x => x.Send(It.IsAny<GetUpComingWarsQuery>(), default))
                .Returns(Task.FromResult(result));

            //Act
            var response = await _sut.GetUpComingWars(DateTime.Now);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public async Task GetUpCommingWars_ShouldReturnProblem_WhenFailure()
        {
            //Arrange
            var result = Result.Failure<IEnumerable<WarModel>>(Error);

            _sender.Setup(x => x.Send(It.IsAny<GetUpComingWarsQuery>(), default))
                .Returns(Task.FromResult(result));

            //Act
            var response = await _sut.GetUpComingWars(DateTime.Now);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<NotFoundObjectResult>(response);
        }

        [Fact]
        public async Task AddClanToWar_ShouldReturnNoContent_WhenSuccess()
        {
            //Arrange
            var result = Result.Success();

            _sender.Setup(x => x.Send(It.IsAny<AddClanWarCommand>(), default))
                .Returns(Task.FromResult(result));

            //Act
            var response = await _sut.AddClanToWar(1, 5, 100);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<NoContentResult>(response);
        }

        [Fact]
        public async Task AddClanToWar_ShouldReturnProblem_WhenFailure()
        {
            //Arrange
            var result = Result.Failure(Error);

            _sender.Setup(x => x.Send(It.IsAny<AddClanWarCommand>(), default))
                .Returns(Task.FromResult(result));

            //Act
            var response = await _sut.AddClanToWar(1, 5, 100);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<NotFoundObjectResult>(response);
        }
    }
}