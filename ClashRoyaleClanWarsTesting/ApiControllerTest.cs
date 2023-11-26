using Moq;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ClashRoyaleClanWarsAPI.API.Controllers;
using ClashRoyaleClanWarsAPI.Domain.Shared;

namespace ClashRoyaleClanWarsAPI.Tests
{
    public class ApiControllerMock : ApiController
    {
        public ApiControllerMock(ISender sender) : base(sender){}
    }


    public class ApiControllerTest : ApiControllerMock
    {
        private readonly ApiControllerMock _sut;
        private static readonly Mock<ISender> MockSender = new Mock<ISender>();

        public ApiControllerTest() : base(MockSender.Object)
        {
            _sut = new ApiControllerMock(MockSender.Object);
        }

        [Fact]
        public void SingleProblem_MustRecognize_AllErrorTypes()
        {

            //Arrange
            var DuplicateIdError = new Error("Model.DuplicateId", "Model.DuplicateId");
            var ModelNotFoundError = new Error("Model.ModelNotFound", "Model.ModelNotFound");
            var IdNotFoundError = new Error("Model.IdNotFound", "Model.IdNotFound");
            var IdsNotMatchError = new Error("Model.IdsNotMatch", "Model.IdsNotMatch");
            var ChallengeClosedError = new Error("Challenge.ChallengeClosed", "Challenge.ChallengeClosed");
            var PlayerNotHaveCardsError = new Error( "Player.PlayerNotHaveCard",  "Player.PlayerNotHaveCard");
            var NullValueError = new Error("Error.NullValue", "Error.NullValue");
            var UsernameNotFoundError = new Error("Auth.UsernameNotFound", "Auth.UsernameNotFound");
            var DuplicateUsernameError = new Error("Auth.DuplicateUsername", "Auth.DuplicateUsername");
            var InvalidCredentialsError = new Error("Auth.InvalidCredentials", "Auth.InvalidCredentials");
            var InvalidPasswordError = new Error("Auth.InvalidPassword", "Auth.InvalidPassword");
            var ValidationError = new Error ("ValidationError", "A validation problem occurred");


            //Act
            var DuplicateIdResponse = Problem (DuplicateIdError);
            var ModelNotFoundResponse = Problem (ModelNotFoundError);
            var IdNotFoundResponse = Problem (IdNotFoundError);
            var IdsNotMatchResponse = Problem (IdsNotMatchError);
            var ChallengeClosedResponse = Problem (ChallengeClosedError);
            var PlayerNotHaveCardsResponse = Problem (PlayerNotHaveCardsError);
            var NullValueResponse = Problem (NullValueError);
            var UsernameNotFoundResponse = Problem (UsernameNotFoundError);
            var DuplicateUsernameResponse = Problem (DuplicateUsernameError);
            var InvalidCredentialsResponse = Problem (InvalidCredentialsError);
            var InvalidPasswordResponse = Problem (InvalidPasswordError);
            var ValidationResponse = Problem (ValidationError);

            //Assert
            Assert.IsType<ConflictObjectResult>(DuplicateIdResponse);
            Assert.IsType<ConflictObjectResult>(DuplicateUsernameResponse);

            Assert.IsType<NotFoundObjectResult>(UsernameNotFoundResponse);
            Assert.IsType<NotFoundObjectResult>(ModelNotFoundResponse);
            Assert.IsType<NotFoundObjectResult>(IdNotFoundResponse);
            Assert.IsType<NotFoundObjectResult>(UsernameNotFoundResponse);

            Assert.IsType<BadRequestObjectResult>(IdsNotMatchResponse);
            Assert.IsType<BadRequestObjectResult>(ChallengeClosedResponse);
            Assert.IsType<BadRequestObjectResult>(PlayerNotHaveCardsResponse);
            Assert.IsType<BadRequestObjectResult>(InvalidCredentialsResponse);
            Assert.IsType<BadRequestObjectResult>(InvalidPasswordResponse);
            Assert.IsType<BadRequestObjectResult>(ValidationResponse);

            Assert.IsType<ObjectResult>(NullValueResponse);
        }

        [Fact]
        public void ArrayProblem_ShouldWork()
        {
            //Arrange
            var Error1 = new Error("Model.DuplicateId", "Model.DuplicateId");
            var Error2 = new Error("Auth.UsernameNotFound", "Auth.UsernameNotFound");
            var Error3 = new Error("Model.IdsNotMatch", "Model.IdsNotMatch");

            Error[] DuplicatedFirst = new Error[3]
            {
                Error1, Error2, Error3
            };

            Error[] UsernameNotFoundFirst = new Error[3]
            {
                Error2, Error1, Error3
            };

            //Act
            var DuplicatedFirstResponse = Problem(DuplicatedFirst);
            var UsernameNotFoundFirstResponse = Problem(UsernameNotFoundFirst);

            //Assert
            Assert.IsType<ConflictObjectResult>(DuplicatedFirstResponse);
            Assert.IsType<NotFoundObjectResult>(UsernameNotFoundFirstResponse);
        }
    }
}