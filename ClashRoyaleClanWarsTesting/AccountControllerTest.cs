using AutoMapper;
using ClashRoyaleClanWarsAPI.API.Common.Mapping.Objects;
using ClashRoyaleClanWarsAPI.Application.Auth;
using ClashRoyaleClanWarsAPI.Application.Auth.Account.Commands.RegisterUser;
using ClashRoyaleClanWarsAPI.Application.Auth.Account.Queries.LoginUser;
using ClashRoyaleClanWarsAPI.Application.Auth.Utils;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ClashRoyaleClanWarsAPI.API.Controllers;
using Moq;
using ClashRoyaleClanWarsAPI.Domain.Shared;
using ClashRoyaleClanWarsAPI.Application.Auth.Response;

namespace ClashRoyaleClanWarsAPI.Tests
{
    public class AccountControllerTest
    { 
        private readonly AccountController _sut;
        private readonly Mock<IMapper> _mapper = new Mock<IMapper>();
        private readonly Mock<ISender> _sender = new Mock<ISender>();

        public AccountControllerTest()
        {
            _sut = new AccountController(_sender.Object ,_mapper.Object);
        }

        [Fact]
        public async Task RegisterUser_ShouldReturnCreated_WhenSuccess()
        {
            //Arrange
            RegisterRequest request = new RegisterRequest()
            {
                Username = "Drackaro",
                Password = "1234",
                ConfirmPassword = "1234"
            };

            var registerModel = _mapper.Object.Map<RegisterModel>(request);
            var command = new RegisterUserCommand(registerModel);
            var result = Result.Success<String>("En talla");

            _sender.Setup(x => x.Send(command, default)).ReturnsAsync(result);

            //Act
            var response = await _sut.RegisterUser(request);

            //Assert
            Assert.IsType<CreatedResult>(response);
        }

        [Fact]
        public async Task RegisterUser_ShouldReturnProblem_WhenFailure()
        {
            //Arrange
            RegisterRequest request = new RegisterRequest()
            {
                Username = "Dracaro",
                Password = "1234",
                ConfirmPassword = "1234"
            };

            var registerModel = _mapper.Object.Map<RegisterModel>(request);
            var command = new RegisterUserCommand(registerModel);
            var result = Result.Failure<String>(new Error("Auth.UsernameNotFound", "Auth.UsernameNotFound"));

            _sender.Setup(x => x.Send(command, default)).Returns(Task.FromResult(result));

            //Act
            var response = await _sut.RegisterUser(request);

            //Assert
            Assert.IsType<NotFoundObjectResult>(response);
        }

        [Fact]
        public async Task Login_ShouldReturnOk_WhenSuccess()
        {
            //Arrange
            LoginRequest request = new LoginRequest()
            {
                Username = "Drackaro",
                Password = "1234"
            };

            var loginModel = _mapper.Object.Map<LoginModel>(request);
            var query = new LoginUserQuery(loginModel);
            var login = new LoginResponse("1", DateTime.Now);
            var result = Result.Success<LoginResponse>(login);

            _sender.Setup(x => x.Send(query, default)).Returns(Task.FromResult(result)); 

            //Act
            var response = await _sut.Login(request);

            //Assert
            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public async Task Login_ShouldReturnProblem_WhenFailure()
        {
            //Arrange
            LoginRequest request = new LoginRequest()
            {
                Username = "Dracaro",
                Password = "1234"
            };

            var loginModel = _mapper.Object.Map<LoginModel>(request);
            var query = new LoginUserQuery(loginModel);
            var result = Result.Failure<LoginResponse>(new Error("Auth.UsernameNotFound", "Auth.UsernameNotFound"));

            _sender.Setup(x => x.Send(query, default)).Returns(Task.FromResult(result)); 

            //Act
            var response = await _sut.Login(request);

            //Assert
            Assert.IsType<NotFoundObjectResult>(response);
        }

        [Fact]
        public async Task RegisterAdmin_ShouldReturnNoContent_WhenSuccess()
        {
            //Arrange
            RegisterRequest request = new RegisterRequest()
            {
                Username = "Drackaro",
                Password = "1234",
                ConfirmPassword = "1234"
            };

            var registerModel = _mapper.Object.Map<RegisterModel>(request);
            var command = new RegisterUserCommand(registerModel, RoleEnum.Admin);
            var result = Result.Success<String>("En talla");

            _sender.Setup(x => x.Send(command, default)).ReturnsAsync(result);

            //Act
            var response = await _sut.RegisterAdmin(request);

            //Assert
            Assert.IsType<NoContentResult>(response);
        }

        [Fact]
        public async Task RegisterAdmin_ShouldReturnProblem_WhenFailure()
        {
            //Arrange
            RegisterRequest request = new RegisterRequest()
            {
                Username = "Dracaro",
                Password = "1234",
                ConfirmPassword = "1234"
            };

            var registerModel = _mapper.Object.Map<RegisterModel>(request);
            var command = new RegisterUserCommand(registerModel, RoleEnum.Admin);
            var result = Result.Failure<String>(new Error("Auth.UsernameNotFound", "Auth.UsernameNotFound"));

            _sender.Setup(x => x.Send(command, default)).Returns(Task.FromResult(result));

            //Act
            var response = await _sut.RegisterAdmin(request);

            //Assert
            Assert.IsType<NotFoundObjectResult>(response);
        }
    }
}