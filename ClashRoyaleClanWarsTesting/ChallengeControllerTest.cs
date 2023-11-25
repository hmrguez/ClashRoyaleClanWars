using Moq;
using AutoMapper;
using ClashRoyaleClanWarsAPI.API.Common.Mapping.Objects;
using ClashRoyaleClanWarsAPI.Application.Common.Commands.AddModel;
using ClashRoyaleClanWarsAPI.Application.Common.Queries.GetModelById;
using ClashRoyaleClanWarsAPI.Application.Models.Challenge.Queries.GetAllOpen;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ClashRoyaleClanWarsAPI.Application.Common.Commands.UpdateModel;
using ClashRoyaleClanWarsAPI.Application.Common.Commands.DeleteModel;
using ClashRoyaleClanWarsAPI.Domain.Models;
using ClashRoyaleClanWarsAPI.API.Controllers;
using ClashRoyaleClanWarsAPI.Domain.Shared;

namespace ClashRoyaleClanWarsAPI.Tests
{
    public class ChallengeControllerTest
    {
        private readonly ChallengeController _sut;
        private readonly Mock<ISender> _sender = new Mock<ISender>();
        private readonly Mock<IMapper> _mapper = new Mock<IMapper>();

        public ChallengeControllerTest()
        {
            _sut = new ChallengeController(_sender.Object, _mapper.Object);
        }

        [Fact]
        public async Task Get_ShouldReturnOk_WhenSuccess()
        {
            //Arrange
            int ChallengeId = 1;
            var query = new GetModelByIdQuery<ChallengeModel, int>(ChallengeId);
            var Challenge = ChallengeModel.Create("Chal1", "Too Hard", 50, 500, DateTime.Now, 72, true, 10, 3);
            var result = Result.Success<ChallengeModel>(Challenge);

            _sender.Setup(x => x.Send(query, default)).Returns(Task.FromResult(result));

            //Act
            var response = await _sut.Get(ChallengeId);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public async Task Get_ShouldReturnProblem_WhenFailure()
        {
            //Arrange
            int ChallengeId = 1;
            var query = new GetModelByIdQuery<ChallengeModel, int>(ChallengeId);
            var result = Result.Failure<ChallengeModel>(new Error("Model.IdNotFound","Model.IdNotFound"));

            _sender.Setup(x => x.Send(query, default)).Returns(Task.FromResult(result));

            //Act
            var response = await _sut.Get(ChallengeId);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<NotFoundObjectResult>(response);
        }

        [Fact]
        public async Task GetAllOpenChallenges_ShouldReturnOk_WhenSuccess()
        {
            //Arrange
            var query = new GetAllOpenChallengeQuery();

            var Challenge1 = ChallengeModel.Create("Chal1", "Too Hard", 50, 500, DateTime.Now, 72, true, 10, 3);
            var Challenge2 = ChallengeModel.Create("Chal2", "Too Easy", 10, 100, DateTime.Now, 72, true, 3, 3);

            ChallengeModel[] Challenges = new ChallengeModel[2]
            {
                Challenge1, Challenge2
            };

            var result = Result.Success<IEnumerable<ChallengeModel>>(Challenges);

            _sender.Setup(x => x.Send(query, default)).Returns(Task.FromResult(result));

            //Act
            var response = await _sut.GetAllOpenChallenges();

            //Assert
            Assert.NotNull(response);
            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public async Task GetAllOpenChallenges_ShouldReturnProblem_WhenFailure()
        {
            //Arrange
            var query = new GetAllOpenChallengeQuery();

            var result = Result.Failure<IEnumerable<ChallengeModel>>(new Error("Model.ModelNotFound","Model.ModelNotFound"));

            _sender.Setup(x => x.Send(query, default)).Returns(Task.FromResult(result));

            //Act
            var response = await _sut.GetAllOpenChallenges();

            //Assert
            Assert.NotNull(response);
            Assert.IsType<NotFoundObjectResult>(response);
        }

        [Fact]
        public async Task Post_ShouldReturnCreated_WhenSuccess()
        {
            //Arrange
            var ChallengeRequest = new AddChallengeRequest();
            var challenge = _mapper.Object.Map<ChallengeModel>(ChallengeRequest);
            var command = new AddModelCommand<ChallengeModel, int>(challenge);
            var result = Result.Success<int>(1);

            _sender.Setup(x => x.Send(command, default)).Returns(Task.FromResult(result));

            //Act
            var response = await _sut.Post(ChallengeRequest);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<CreatedResult>(response);
        }

        [Fact]
        public async Task Post_ShouldReturnProblem_WhenFailure()
        {
            //Arrange
            var ChallengeRequest = new AddChallengeRequest();
            var challenge = _mapper.Object.Map<ChallengeModel>(ChallengeRequest);
            var command = new AddModelCommand<ChallengeModel, int>(challenge);
            var result = Result.Failure<int>( new Error("Model.ModelNotFound","Model.ModelNotFound"));

            _sender.Setup(x => x.Send(command, default)).Returns(Task.FromResult(result));

            //Act
            var response = await _sut.Post(ChallengeRequest);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<NotFoundObjectResult>(response);
        }

        [Fact]
        public async Task Put_ShouldReturnNoContent_WhenSuccess()
        {
            //Arrange
            int ChallengeId = 1;
            var ChallengeRequest = new UpdateChallengeRequest()
            {
                Id = 1
            };

            var challenge = _mapper.Object.Map<ChallengeModel>(ChallengeRequest);
            var command = new UpdateModelCommand<ChallengeModel, int>(challenge);
            var result = Result.Success();

            _sender.Setup(x => x.Send(command, default)).Returns(Task.FromResult(result));

            //Act
            var response = await _sut.Put(ChallengeId, ChallengeRequest);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<NoContentResult>(response);
        }

        [Fact]
        public async Task Put_ShouldReturnProblem_WhenFailure()
        {
            //Arrange
            int ChallengeId = 1;
            var ChallengeRequest = new UpdateChallengeRequest()
            {
                Id = 1
            };

            var challenge = _mapper.Object.Map<ChallengeModel>(ChallengeRequest);
            var command = new UpdateModelCommand<ChallengeModel, int>(challenge);
            var result = Result.Failure(new Error("Model.ModelNotFound","Model.ModelNotFound"));

            _sender.Setup(x => x.Send(command, default)).Returns(Task.FromResult(result));

            //Act
            var response = await _sut.Put(ChallengeId, ChallengeRequest);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<NotFoundObjectResult>(response);
        }

        [Fact]
        public async Task Put_ShouldReturnError_WhenDifferentsIds()
        {
            //Arrange
            int ChallengeId = 1;
            var ChallengeRequest = new UpdateChallengeRequest()
            {
                Id = 2
            };

            //Act
            var response = await _sut.Put(ChallengeId, ChallengeRequest);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<BadRequestObjectResult>(response);
        }

        [Fact]
        public async Task Delete_ShouldReturnNoContent_WhenSuccess()
        {
            //Arrange
            int ChallengeId = 1;
            var command = new DeleteModelCommand<ChallengeModel, int>(ChallengeId);
            var result = Result.Success();

            _sender.Setup(x => x.Send(command, default)).Returns(Task.FromResult(result));

            //Act
            var response = await _sut.Delete(ChallengeId);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<NoContentResult>(response);
        }

        [Fact]
        public async Task Delete_ShouldReturnProblem_WhenFailure()
        {
            //Arrange
            int ChallengeId = 1;
            var command = new DeleteModelCommand<ChallengeModel, int>(ChallengeId);
            var result = Result.Failure(new Error("Model.ModelNotFound","Model.ModelNotFound"));

            _sender.Setup(x => x.Send(command, default)).Returns(Task.FromResult(result));

            //Act
            var response = await _sut.Delete(ChallengeId);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<NotFoundObjectResult>(response);
        }
    }
}