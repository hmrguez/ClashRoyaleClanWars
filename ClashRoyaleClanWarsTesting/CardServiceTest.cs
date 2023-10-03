 using Xunit;
using Moq;
using ClashRoyaleClanWarsAPI.Data;
using ClashRoyaleClanWarsAPI.Models;
using ClashRoyaleClanWarsAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace ClashRoyaleClanWarsAPI.Tests
{
    public class CardServiceTests
    {
        // Clase derivada que hereda de CardModel
        public class Goblin : CardModel
        {
            public Goblin()
            {
                
            }

            // Otras propiedades específicas de la carta Goblin
        }

        [Fact]
        public async Task Add_ShouldReturnId_WhenModelIsValid()
        {
            // Arrange
            var mockContext = new Mock<DataContext>();
            var mockSet = new Mock<DbSet<CardModel>>();
            mockContext.Setup(c => c.Cards).Returns(mockSet.Object);
            var service = new CardService(mockContext.Object);
            // Usar la clase Goblin para crear el modelo
            var model = new Goblin();

            // Act
            var result = await service.Add(model);

            // Assert
            Assert.Equal(model.Id, result);
            mockSet.Verify(s => s.Add(model), Times.Once());
            mockContext.Verify(c => c.SaveChangesAsync(new CancellationToken()), Times.Once());
        }
    }
}