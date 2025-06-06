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
        public void Post_ValidUserDTO_ReturnsCreatedAtRoute()
        {

            using (var serviceScope = _factory.Services.CreateScope())
            {
                var userController = serviceScope.ServiceProvider.GetService<UserController>();

                var userDto = new UserDTO
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe"
                };

                userController.Post(userDto);

            }
        }


    }
}