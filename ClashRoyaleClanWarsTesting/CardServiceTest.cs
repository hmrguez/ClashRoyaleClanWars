using Xunit;
using ClashRoyaleClanWarsAPI.Data;
using ClashRoyaleClanWarsAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.Extensions.Configuration;

namespace ClashRoyaleClanWarsAPI.Tests
{
    public class CardServiceTest : IClassFixture<CardServiceTest>
    {
        private readonly CardService _cardService;
        private readonly DataContext _context;

        public CardServiceTest()
        {
            // Create an in-memory database for testing
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

            // Initialize the database context and the service
            _context = new DataContext(options, configuration);
            _cardService = new CardService(_context);
        }

        [Fact]
        public async Task AddAllCards_ShouldAddCardsToDatabase()
        {
            // Arrange
            _context.Cards.RemoveRange(_context.Cards);
            await _context.SaveChangesAsync();

            // Act
            await _cardService.AddAllCards();

            // Assert
            Assert.Equal(109, await _context.Cards.CountAsync());
        }

        [Fact]
        public async Task GetCardsByNameAsync_ShouldReturnCardsWithName()
        {
            // Arrange
            await _cardService.AddAllCards(); // Add all cards to the database
            var name = "P.E.K.K.A"; // The name to search for

            // Act
            var cards = await _cardService.GetCardsByNameAsync(name); // Get the cards with the name

            // Assert
            Assert.NotEmpty(cards); // Check that the cards are not empty
            Assert.All(cards, c => c.Name.Contains(name)); // Check that all cards contain the name
            Assert.Equal(cards.Count(), 2);
        }
    }
}
