using ClashRoyaleClanWarsAPI.Application.Auth.User.Commands.DeleteUser;
using ClashRoyaleClanWarsAPI.Application.Auth.User.Commands.UpdateRole;
using ClashRoyaleClanWarsAPI.Application.Auth.User.Queries.GetAllUser;
using ClashRoyaleClanWarsAPI.Application.Auth.User.Queries.GetUserById;
using ClashRoyaleClanWarsAPI.Application.Auth.User.Queries.GetUserByName;
using ClashRoyaleClanWarsAPI.Application.Auth.Utils;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ClashRoyaleClanWarsAPI.Domain.Errors;
using Moq;
using ClashRoyaleClanWarsAPI.API.Controllers;
using ClashRoyaleClanWarsAPI.Domain.Shared;
using ClashRoyaleClanWarsAPI.Application.Auth.User;
using ClashRoyaleClanWarsAPI.Application.Auth.Response;
using ClashRoyaleClanWarsAPI.Domain.Models;

namespace ClashRoyaleClanWarsAPI.Tests
{
    public class UserControllerTest
    {
        private readonly UserController _sut;
        private readonly Mock<ISender> _sender = new Mock<ISender>();
        private readonly Error Error = new Error(ErrorCode.IdNotFound,"Id not found");
        private readonly Guid guid = Guid.NewGuid();

        public UserControllerTest()
        {
            _sut = new UserController(_sender.Object);
        }

        [Fact]
        public async Task GetAll_ShouldReturnOk_WhenSuccess()
        {
            //Arrange
            var result = Result.Success(It.IsAny<IEnumerable<UserResponse>>());

            _sender.Setup(x => x.Send(It.IsAny<GetAllUserQuery>(), default))
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
            var result = Result.Failure<IEnumerable<UserResponse>>(Error);

            _sender.Setup(x => x.Send(It.IsAny<GetAllUserQuery>(), default))
                .Returns(Task.FromResult(result));

            //Act
            var response = await _sut.GetAll();

            //Assert
            Assert.NotNull(response);
            Assert.IsType<NotFoundObjectResult>(response);
        }

        [Fact]
        public async Task GetUserByUserName_ShouldReturnOk_WhenSuccess()
        {
            //Arrange
            string Name = "Dráckaro";
            var result = Result.Success(It.IsAny<UserResponse>());

            _sender.Setup(x => x.Send(It.IsAny<GetUserByNameQuery>(), default))
                .Returns(Task.FromResult(result));

            //Act
            var response = await _sut.GetUserByUsername(Name);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public async Task GetUserByUserName_ShouldReturnProblem_WhenFailure()
        {
            //Arrange
            string Name = "Dráckaro";
            var result = Result.Failure<UserResponse>(Error);

            _sender.Setup(x => x.Send(It.IsAny<GetUserByNameQuery>(), default))
                .Returns(Task.FromResult(result));

            //Act
            var response = await _sut.GetUserByUsername(Name);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<NotFoundObjectResult>(response);
        }

        [Fact]
        public async Task GetUserById_ShouldReturnOk_WhenSuccess()
        {
            //Arrange
            var result = Result.Success(It.IsAny<UserResponse>());

            _sender.Setup(x => x.Send(It.IsAny<GetUserByIdQuery>(), default))
                .Returns(Task.FromResult(result));

            //Act
            var response = await _sut.GetUserById(guid);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public async Task GetUserById_ShouldReturnProblem_WhenFailure()
        {
            //Arrange
            var result = Result.Failure<UserResponse>(Error);

            _sender.Setup(x => x.Send(It.IsAny<GetUserByIdQuery>(), default))
                .Returns(Task.FromResult(result));

            //Act
            var response = await _sut.GetUserById(guid);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<NotFoundObjectResult>(response);
        }

        [Fact]
        public async Task Delete_ShouldReturnNoContent_WhenSuccess()
        {
            //Arrange
            var result = Result.Success();

            _sender.Setup(x => x.Send(It.IsAny<DeleteUserCommand>(), default))
                .Returns(Task.FromResult(result));

            //Act
            var response = await _sut.Delete(guid);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<NoContentResult>(response);
        }

        [Fact]
        public async Task Delete_ShouldReturnProblem_WhenFailure()
        {
            //Arrange
            var result = Result.Failure(Error);

            _sender.Setup(x => x.Send(It.IsAny<DeleteUserCommand>(), default))
                .Returns(Task.FromResult(result));

            //Act
            var response = await _sut.Delete(guid);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<NotFoundObjectResult>(response);
        }

        [Fact]
        public async Task UpdateRole_ShouldReturnNoContent_WhenSuccess()
        {
            //Arrange
            var result = Result.Success();

            _sender.Setup(x => x.Send(It.IsAny<UpdateRoleCommand>(), default))
                .Returns(Task.FromResult(result));

            //Act
            var response = await _sut.UpdateRole(guid, RoleEnum.Admin);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<NoContentResult>(response);
        }

        [Fact]
        public async Task UpdateRole_ShouldReturnProblem_WhenFailure()
        {
            //Arrange
            var result = Result.Failure(Error);

            _sender.Setup(x => x.Send(It.IsAny<UpdateRoleCommand>(), default))
                .Returns(Task.FromResult(result));

            //Act
            var response = await _sut.UpdateRole(guid, RoleEnum.Admin);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<NotFoundObjectResult>(response);
        }
    }
}