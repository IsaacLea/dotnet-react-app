using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using ReactApp1.Server.Controllers;
using ReactApp1.Server.DTO;
using ReactApp1.Server.Service;

namespace ReactApp1.Server.Tests.Controllers
{
    public class UserControllerTests
    {
        [Fact]
        public void Post_ValidUserDTO_ReturnsCreatedAtRoute()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<UserController>>();
            var mapperMock = new Mock<IMapper>();
            var userServiceMock = new Mock<IUserService>();

            var userDto = new UserDTO
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe"
            };

            var controller = new UserController(
                loggerMock.Object,
                mapperMock.Object,
                userServiceMock.Object
            );

            // Act
            var result = controller.Post(userDto);

            // Assert
            userServiceMock.Verify(s => s.AddUser(userDto), Times.Once);
            var createdAtRouteResult = Assert.IsType<CreatedAtRouteResult>(result);
            Assert.Equal("GetUsers", createdAtRouteResult.RouteName);
            Assert.Equal(userDto, createdAtRouteResult.Value);
        }

        [Fact]
        public void Post_NullUserDTO_ReturnsBadRequest()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<UserController>>();
            var mapperMock = new Mock<IMapper>();
            var userServiceMock = new Mock<IUserService>();

            var controller = new UserController(
                loggerMock.Object,
                mapperMock.Object,
                userServiceMock.Object
            );

            // Act
            var result = controller.Post(null);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("User data is required.", badRequestResult.Value);
        }
    }
}