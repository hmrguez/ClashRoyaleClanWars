using Xunit;
using ClashRoyaleClanWarsAPI.Data;
using ClashRoyaleClanWarsAPI.Exceptions;
using ClashRoyaleClanWarsAPI.Interfaces.ServicesInterfaces;
using ClashRoyaleClanWarsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClashRoyaleClanWarsAPI.Services.Tests
{
    public class CardServiceTests
    {
        [Fact]
        public async Task Add_ShouldAddCardToContext()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "Test_Add_ShouldAddCardToContext")
                .Options;

            using (var context = new DataContext(options))
            {
                var service = new CardService(context);
                var card = new CardModel { Id = 1, Name = "Test Card" };

                // Act
                await service.Add(card);

                // Assert
                var result = await context.Cards.FindAsync(card.Id);
                Assert.NotNull(result);
                Assert.Equal(card.Name, result.Name);
            }
        }
    }
}