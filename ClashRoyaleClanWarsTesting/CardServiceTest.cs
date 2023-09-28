using Xunit;
using ClashRoyaleClanWarsAPI.Data;
using ClashRoyaleClanWarsAPI.Exceptions;
using ClashRoyaleClanWarsAPI.Interfaces.ServicesInterfaces;
using ClashRoyaleClanWarsAPI.Models;
using Microsoft.EntityFrameworkCore;
using ClashRoyaleClanWarsAPI.Services;

namespace ClashRoyaleClanWarsAPI.Services.Tests
{
    public class CardServiceTests
    {
        private readonly DataContext _context;
        private readonly CardService _cardService;

        public CardServiceTests()
        {
            _context = new DataContext();
            _cardService = new CardService(_context);
        }

        [Fact]
        public async Task Add_ValidCard_ReturnsNewCardId()
        {
            // Arrange
            var card = new CardModel { Name = "Test Card" };

            // Act
            var result = await _cardService.Add(card);

            // Assert
            Assert.True(result > 0);
        }

        [Fact]
        public async Task AddAllCards_ValidCards_AddsAllCardsToDatabase()
        {
            // Act
            await _cardService.AddAllCards();

            // Assert
            Assert.Equal(9, await _context.Cards.CountAsync());
        }

        [Fact]
        public async Task Delete_ExistingCard_RemovesCardFromDatabase()
        {
            // Arrange
            var card = new CardModel { Name = "Test Card" };
            await _cardService.Add(card);

            // Act
            await _cardService.Delete(card.Id);

            // Assert
            Assert.DoesNotContain(card, await _context.Cards.ToListAsync());
        }

        [Fact]
        public async Task ExistsId_ExistingId_ReturnsTrue()
        {
            // Arrange
            var card = new CardModel { Name = "Test Card" };
            await _cardService.Add(card);

            // Act
            var result = await _cardService.ExistsId(card.Id);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsAllCards()
        {
            // Arrange
            var cards = new List<CardModel>
            {
                new CardModel { Name = "Test Card 1" },
                new CardModel { Name = "Test Card 2" },
                new CardModel { Name = "Test Card 3" }
            };
            await _context.Cards.AddRangeAsync(cards);
            await _context.SaveChangesAsync();

            // Act
            var result = await _cardService.GetAllAsync();

            // Assert
            Assert.Equal(cards.Count, result.Count());
        }

        [Fact]
        public async Task GetCardsByNameAsync_ReturnsMatchingCards()
        {
            // Arrange
            var cards = new List<CardModel>
            {
                new CardModel { Name = "Test Card 1" },
                new CardModel { Name = "Test Card 2" },
                new CardModel { Name = "Another Test Card" }
            };
            await _context.Cards.AddRangeAsync(cards);
            await _context.SaveChangesAsync();

            // Act
            var result = await _cardService.GetCardsByNameAsync("Test");

            // Assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetSingleByIdAsync_ExistingId_ReturnsCard()
        {
            // Arrange
            var card = new CardModel { Name = "Test Card" };
            await _cardService.Add(card);

            // Act
            var result = await _cardService.GetSingleByIdAsync(card.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(card.Id, result.Id);
            Assert.Equal(card.Name, result.Name);
        }

        [Fact]
        public async Task Update_ExistingCard_UpdatesCardInDatabase()
        {
            // Arrange
            var card = new CardModel { Name = "Test Card" };
            await _cardService.Add(card);
            card.Name = "Updated Test Card";

            // Act
            await _cardService.Update(card);

            // Assert
            var updatedCard = await _cardService.GetSingleByIdAsync(card.Id);
            Assert.NotNull(updatedCard);
            Assert.Equal(card.Id, updatedCard.Id);
            Assert.Equal(card.Name, updatedCard.Name);
        }
    }
}
