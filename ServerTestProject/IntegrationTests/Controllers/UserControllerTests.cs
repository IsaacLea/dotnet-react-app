using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using ReactApp1.Server.Controllers;
using ReactApp1.Server.DTO;

namespace ServerTestProject.IntegrationTests.Controllers
{
    public class UserControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;


        public UserControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            //_client = _factory.CreateClient();
        }

        [Fact]
        public void Get_UsersByName()
        {
            using var serviceScope = _factory.Services.CreateScope();
            var userController = serviceScope.ServiceProvider.GetService<UserController>();
            Assert.NotNull(userController);
            var users = userController.Get();
            Assert.NotNull(users);
            Assert.NotEmpty(users);
        }
        [Fact]
        public void Post_ValidUserDTO_ReturnsCreatedAtRoute()
        {

            using var serviceScope = _factory.Services.CreateScope();
            var userController = serviceScope.ServiceProvider.GetService<UserController>();

            Assert.NotNull(userController);

            var userDto = new UserDTO
            {
                FirstName = "John",
                LastName = "Doe"
            };

            var postDTO = new PostDTO
            {
                Text = "Sample Post"
            };

            userDto.Posts.Add(postDTO);


            userController.Post(userDto);
        }


    }
}