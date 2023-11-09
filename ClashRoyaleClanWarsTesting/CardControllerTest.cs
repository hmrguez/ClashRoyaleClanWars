// using ClashRoyaleClanWarsAPI.Exceptions;
// using ClashRoyaleClanWarsAPI.Interfaces.ServicesInterfaces;
// using ClashRoyaleClanWarsAPI.Models;
// using ClashRoyaleClanWarsAPI.Utils;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using ClashRoyaleClanWarsAPI.Controllers.ModelControllers;
// using Moq;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// using Xunit;
// using System.Security.Claims;
// using Microsoft.AspNetCore.Http;
//
//
//
//
// namespace ClashRoyaleClanWarsAPI.Test.Controllers.ModelControllers
// {
//     public class FakeCard : CardModel
//     {
//         public FakeCard()
//         {}
//     }
//
//     public static class TestHelper
//     {
//         public static void SetFakeUser(this ControllerContext controllerContext, ClaimsPrincipal user)
//         {
//             controllerContext.HttpContext = new DefaultHttpContext { User = user };
//         }
//     }
//
//     public class CardControllerTests
//     {
//         [Fact]
//         public async Task Get_ReturnsOkResult()
//         {
//             // Arrange
//             int id = 5;
//             var cardServiceMock = new Mock<ICardService>();
//             cardServiceMock.Setup(x => x.GetSingleByIdAsync(id)).ReturnsAsync(It.IsAny<CardModel>());
//
//             var controller = new CardController(cardServiceMock.Object);
//
//             // Act
//             var result = await controller.Get(id);
//
//             // Assert
//             Assert.IsType<OkObjectResult>(result);
//         }
//
//         [Fact]
//         public async Task Get_ReturnsNotFoundResult_WhenModelNotFoundExceptionIsThrown()
//         {
//             // Arrange
//             int id = 5;
//             var cardServiceMock = new Mock<ICardService>();
//             cardServiceMock.Setup(x => x.GetSingleByIdAsync(id)).ThrowsAsync(new ModelNotFoundException<CardModel>());
//
//             var controller = new CardController(cardServiceMock.Object);
//
//             // Act
//             var result = await controller.Get(id);
//
//             // Assert
//             Assert.IsType<NotFoundObjectResult>(result);
//         }
//
//         [Fact]
//         public async Task Get_ReturnsNotFoundResult_WhenIdNotFoundExceptionIsThrown()
//         {
//             // Arrange
//             int id = 5;
//             var cardServiceMock = new Mock<ICardService>();
//             cardServiceMock.Setup(x => x.GetSingleByIdAsync(id)).ThrowsAsync(new IdNotFoundException<CardModel, int>(id));
//
//             var controller = new CardController(cardServiceMock.Object);
//
//             // Act
//             var result = await controller.Get(id);
//
//             // Assert
//             Assert.IsType<NotFoundObjectResult>(result);
//         }
//
//         [Fact]
//         public async Task GetAll_ReturnsOkResult()
//         {
//             // Arrange
//             var cardServiceMock = new Mock<ICardService>();
//             cardServiceMock.Setup(x => x.GetAllAsync()).ReturnsAsync(It.IsAny<IEnumerable<CardModel>>());
//
//             var controller = new CardController(cardServiceMock.Object);
//
//             // Act
//             var result = await controller.GetAll();
//
//             // Assert
//             Assert.IsType<OkObjectResult>(result);
//         }
//
//         [Fact]
//         public async Task GetAll_ReturnsNotFoundResult_WhenModelNotFoundExceptionIsThrown()
//         {
//             // Arrange
//             var cardServiceMock = new Mock<ICardService>();
//             cardServiceMock.Setup(x => x.GetAllAsync()).ThrowsAsync(new ModelNotFoundException<CardModel>());
//
//             var controller = new CardController(cardServiceMock.Object);
//
//             // Act
//             var result = await controller.GetAll();
//
//             // Assert
//             Assert.IsType<NotFoundObjectResult>(result);
//         }
//
//         [Fact]
//         public async Task PostAllCards_SuperAdmin_ReturnsCreatedResponse()
//         {
//             // Arrange
//             var mockCardService = new Mock<ICardService>();
//             mockCardService.Setup(s => s.AddAllCards()).Returns(Task.CompletedTask);
//             var cardController = new CardController(mockCardService.Object);
//             var fakeUser = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
//             {
//                 new Claim(ClaimTypes.Name, "testuser"),
//                 new Claim(ClaimTypes.Role, UserRoles.SUPERADMIN),
//             }, "Test"));
//             
//             cardController.ControllerContext.SetFakeUser(fakeUser);
//             // Act
//             var result = await cardController.PostAllCards();
//
//             // Assert
//             Assert.IsType<CreatedResult>(result);
//         }
//
//         [Fact]
//         public async Task Put_ValidIdAndCardModel_ReturnsNoContentResponse()
//         {
//             // Arrange
//             var mockCardService = new Mock<ICardService>();
//             mockCardService.Setup(s => s.Update(It.IsAny<CardModel>())).Returns(Task.CompletedTask);
//             var cardController = new CardController(mockCardService.Object);
//             var id = 1;
//             var cardModel = new FakeCard { Id = id };
//
//             // Act
//             var result = await cardController.Put(id, cardModel);
//
//             // Assert
//             Assert.IsType<NoContentResult>(result);
//         }
//
//         [Fact]
//         public async Task Delete_ValidId_ReturnsNoContentResponse()
//         {
//             // Arrange
//             var mockCardService = new Mock<ICardService>();
//             mockCardService.Setup(s => s.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
//             var cardController = new CardController(mockCardService.Object);
//             var id = 1;
//
//             // Act
//             var result = await cardController.Delete(id);
//
//             // Assert
//             Assert.IsType<NoContentResult>(result);
//         }
//     }
// }