/*using ClashRoyaleClanWarsAPI.Exceptions;
using ClashRoyaleClanWarsAPI.Interfaces.ServicesInterfaces;
using ClashRoyaleClanWarsAPI.Models;
using ClashRoyaleClanWarsAPI.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ClashRoyaleClanWarsAPI.Controllers.ModelControllers;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace ClashRoyaleClanWarsAPI.Test.Controllers.ModelControllers
{
    public class CardControllerTests
    {
        [Fact]
        public async Task Get_ReturnsOkResult()
        {
            // Arrange
            int id = 5;
            var cardServiceMock = new Mock<ICardService<CardModel>>();
            cardServiceMock.Setup(x => x.GetSingleByIdAsync(id)).ReturnsAsync(It.IsAny<CardModel>());

            var controller = new CardController(cardServiceMock.Object);

            // Act
            var result = await controller.Get(id);

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public async Task Get_ReturnsNotFoundResult_WhenModelNotFoundExceptionIsThrown()
        {
            // Arrange
            int id = 5;
            var cardServiceMock = new Mock<ICardService<CardModel>>();
            cardServiceMock.Setup(x => x.GetSingleByIdAsync(id)).ThrowsAsync(new ModelNotFoundException<CardModel>());

            var controller = new CardController(cardServiceMock.Object);

            // Act
            var result = await controller.Get(id);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result.Result);
        }

        [Fact]
        public async Task Get_ReturnsNotFoundResult_WhenIdNotFoundExceptionIsThrown()
        {
            // Arrange
            int id = 5;
            var cardServiceMock = new Mock<ICardService<CardModel>>();
            cardServiceMock.Setup(x => x.GetSingleByIdAsync(id)).ThrowsAsync(new IdNotFoundException<CardModel>(id));

            var controller = new CardController(cardServiceMock.Object);

            // Act
            var result = await controller.Get(id);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result.Result);
        }

        [Fact]
        public async Task GetAll_ReturnsOkResult()
        {
            // Arrange
            var cardServiceMock = new Mock<ICardService<CardModel>>();
            cardServiceMock.Setup(x => x.GetAllAsync()).ReturnsAsync(It.IsAny<IEnumerable<CardModel>>());

            var controller = new CardController(cardServiceMock.Object);

            // Act
            var result = await controller.GetAll();

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public async Task GetAll_ReturnsNotFoundResult_WhenModelNotFoundExceptionIsThrown()
        {
            // Arrange
            var cardServiceMock = new Mock<ICardService<CardModel>>();
            cardServiceMock.Setup(x => x.GetAllAsync()).ThrowsAsync(new ModelNotFoundException<CardModel>());

            var controller = new CardController(cardServiceMock.Object);

            // Act
            var result = await controller.GetAll();

            // Assert
            Assert.IsType<NotFoundObjectResult>(result.Result);
        }
    }
}*/