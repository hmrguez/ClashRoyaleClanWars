using Moq;
using AutoMapper;
using ClashRoyaleClanWarsAPI.API.Common.Mapping.Objects;
using ClashRoyaleClanWarsAPI.API.Common.Mapping.Utils;
using ClashRoyaleClanWarsAPI.Application.Common.Commands.DeleteModel;
using ClashRoyaleClanWarsAPI.Application.Common.Commands.UpdateModel;
using ClashRoyaleClanWarsAPI.Application.Common.Queries.GetAllModel;
using ClashRoyaleClanWarsAPI.Application.Common.Queries.GetModelById;
using ClashRoyaleClanWarsAPI.Application.Models.Card.Queries.GetCardsByName;
using ClashRoyaleClanWarsAPI.Domain.Models.Card;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ClashRoyaleClanWarsAPI.API.Controllers;
using ClashRoyaleClanWarsAPI.Domain.Shared;
using ClashRoyaleClanWarsAPI.Domain.Enum;
using ClashRoyaleClanWarsAPI.Domain.Models.Card.Implementation;


namespace ClashRoyaleClanWarsAPI.Tests
{
    public class CardControllerTest
    {
        private readonly CardController _sut;
        private readonly Mock<ISender> _sender = new Mock<ISender>();
        private readonly Mock<IMapper> _mapper = new Mock<IMapper>();
        private readonly Mock<CardModel> _card = new Mock<CardModel>();

        public CardControllerTest()
        {
            _sut = new CardController(_sender.Object, _mapper.Object);
        }

        [Fact]
        public async Task Get_ShouldReturnOk_WhenSuccess()
        {
            //Arrange
            int CardId = 1;
            var query = new GetModelByIdQuery<CardModel, int>(CardId);
            var result = Result.Success<CardModel>(_card.Object);

            _sender.Setup(x => x.Send(query, default)).Returns(Task.FromResult(result));


            //Act
            var response = await _sut.Get(CardId);

            //Arrange
            Assert.NotNull(response);
            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public async Task Get_ShouldReturnProblem_WhenFailure()
        {
            //Arrange
            int CardId = 1;
            var query = new GetModelByIdQuery<CardModel, int>(CardId);
            var result = Result.Failure<CardModel>(new Error("Model.IdNotFound","Model.IdNotFound"));

            _sender.Setup(x => x.Send(query, default)).Returns(Task.FromResult(result));


            //Act
            var response = await _sut.Get(CardId);

            //Arrange
            Assert.NotNull(response);
            Assert.IsType<NotFoundObjectResult>(response);
        }

        [Fact]
        public async Task GetAll_ShouldReturnOk()
        {
            //Arrange
            var query = new GetAllModelQuery<CardModel, int>();
            CardModel[] Cards = new CardModel[2]
            {
                _card.Object, _card.Object
            };

            var result = Result.Success<IEnumerable<CardModel>>(Cards);

            _sender.Setup(x => x.Send(query, default)).Returns(Task.FromResult(result));

            //Act
            var response = await _sut.GetAll();

            //Arrange
            Assert.NotNull(response);
            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public async Task GetCardsByName_ShouldReturnOk()
        {
            //Arrange
            string cardName = "P.E.K.K.A";
            var query = new GetCardsByNameQuery(cardName);

            CardModel[] Cards = new CardModel[2]
            {
                _card.Object, _card.Object
            };

            var result = Result.Success<IEnumerable<CardModel>>(Cards);

            _sender.Setup(x => x.Send(query, default)).Returns(Task.FromResult(result));

            //Act
            var response = await _sut.GetCardsByName(cardName);

            //Arrange
            Assert.NotNull(response);
            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public async Task Put_ShouldReturnNoContent_WhenValidData()
        {
            //Arrange
            int CardId = 1;
            var cardRequest = new CardRequest()
            {
                Id = 1,
                Type = TypeCardEnum.Troop
            };

            var Card = MapCardFromTypeEnum.MapCard(cardRequest, _mapper.Object);
            var command = new UpdateModelCommand<CardModel, int>(Card);
            var result = Result.Success();

            _sender.Setup(x => x.Send(command, default)).Returns(Task.FromResult(result));
            _mapper.Setup(x => x.Map<TroopModel>(cardRequest)).Returns(new TroopModel());

            //Act
            var response = await _sut.Put(CardId, cardRequest);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<NoContentResult>(response);
        }

        [Fact]
        public async Task Put_ShouldReturnError_WhenDifferentsIds()
        {
            //Arrange
            int CardId = 1;
            var cardRequest = new CardRequest()
            {
                Id = 2,
            };
            
            //Act
            var response = await _sut.Put(CardId, cardRequest);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<BadRequestObjectResult>(response);
        }

        [Fact]
        public async Task Put_ShouldReturnError_WhenCardIsNull()
        {
            //Arrange
            int CardId = 1;
            var cardRequest = new CardRequest()
            {
                Id = 1,
            };

            //Act
            var response = await _sut.Put(CardId, cardRequest);

            //Assert
            Assert.NotNull(response);
            Assert.IsType<ObjectResult>(response);
        }

        [Fact]
        public async Task Delete_ShouldReturnNoContent_WhenSuccess()
        {
            //Arrange
            int CardId = 1;
            var commandDelete = new DeleteModelCommand<CardModel, int>(CardId);
            var result = Result.Success();

            _sender.Setup(x => x.Send(commandDelete, default)).Returns(Task.FromResult(result));

            //Act
            var response = await _sut.Delete(CardId);

            //Arrange
            Assert.NotNull(response);
            Assert.IsType<NoContentResult>(response);
        }

        public async Task Delete_ShouldReturnProblem_WhenFailure()
        {
            //Arrange
            int CardId = 1;
            var commandDelete = new DeleteModelCommand<CardModel, int>(CardId);
            var result = Result.Failure(new Error("Model.IdNotFound","Model.IdNotFound"));

            _sender.Setup(x => x.Send(commandDelete, default)).Returns(Task.FromResult(result));

            //Act
            var response = await _sut.Delete(CardId);

            //Arrange
            Assert.NotNull(response);
            Assert.IsType<NotFoundObjectResult>(response);
        }
    }
}