using Xunit;
using Moq;
using ClashRoyaleClanWarsAPI.Exceptions;
using ClashRoyaleClanWarsAPI.Interfaces.ServicesInterfaces;
using ClashRoyaleClanWarsAPI.Models;
using ClashRoyaleClanWarsAPI.Utils;
using Microsoft.AspNetCore.Mvc;
using ClashRoyaleClanWarsAPI.Controllers;

namespace ClashRoyaleClanWarsAPI.Controllers.Tests
{
    public class CardControllerTests
    {
        private readonly ICardService<CardModel> _cardService;
        private readonly CardController _cardController;

        public CardControllerTests()
        {
            _cardService = new Mock<ICardService<CardModel>>().Object;
            _cardController = new CardController(_cardService);
        }

        [Fact]
        public async Task Get_ValidId_ReturnsCard()
        {
            // Arrange
            var card = new CardModel { Id = 1, Name = "Test Card" };
            _cardService.Setup(x => x.GetSingleByIdAsync(card.Id)).ReturnsAsync(card);

            // Act
            var result = await _cardController.Get(card.Id);

            // Assert
            Assert.NotNull(result.Value);
            Assert.Equal(card.Id, result.Value.Data.Id);
            Assert.Equal(card.Name, result.Value.Data.Name);
        }

        [Fact]
        public async Task Get_InvalidId_ReturnsNotFound()
        {
            // Arrange
            var id = 1;
            _cardService.Setup(x => x.GetSingleByIdAsync(id)).Throws(new ModelNotFoundException<CardModel>());

            // Act
            var result = await _cardController.Get(id);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result.Result);
        }

        [Fact]
        public async Task GetAll_ReturnsAllCards()
        {
            // Arrange
            var cards = new List<CardModel>
            {
                new CardModel { Id = 1, Name = "Test Card 1" },
                new CardModel { Id = 2, Name = "Test Card 2" },
                new CardModel { Id = 3, Name = "Test Card 3" }
            };
            _cardService.Setup(x => x.GetAllAsync()).ReturnsAsync(cards);

            // Act
            var result = await _cardController.GetAll();

            // Assert
            Assert.NotNull(result.Value);
            Assert.Equal(cards.Count, result.Value.Data.Count());
        }

        [Fact]
        public async Task PostAllCards_ReturnsCreated()
        {
            // Arrange
            _cardService.Setup(x => x.AddAllCards()).Returns(Task.CompletedTask);

            // Act
            var result = await _cardController.PostAllCards();

            // Assert
            Assert.IsType<CreatedAtActionResult>(result.Result);
        }

        [Fact]
        public async Task Put_ValidIdAndCardModel_ReturnsNoContent()
        {
            // Arrange
            var id = 1;
            var cardModel = new CardModel { Id = id };
            _cardService.Setup(x => x.Update(cardModel)).Returns(Task.CompletedTask);

            // Act
            var result = await _cardController.Put(id, cardModel);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task Put_InvalidIdAndCardModel_ReturnsBadRequest()
        {
            // Arrange
            var id = 1;
            var cardModel = new CardModel { Id = 2 };
            _cardService.Setup(x => x.Update(cardModel)).Returns(Task.CompletedTask);

            // Act
            var result = await _cardController.Put(id, cardModel);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Delete_ValidId_ReturnsNoContent()
        {
            // Arrange
            var id = 1;
            _cardService.Setup(x => x.Delete(id)).Returns(Task.CompletedTask);

            // Act
            var result = await _cardController.Delete(id);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}