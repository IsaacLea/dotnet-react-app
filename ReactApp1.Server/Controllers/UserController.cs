using Microsoft.AspNetCore.Mvc;
using ReactApp1.Server.DAL;
using ReactApp1.Server.Models;

namespace ReactApp1.Server.Controllers
{


    [ApiController]
    [Route("[controller]")]
    public class UserController(ILogger<UserController> logger, MyDBContext dbContext) : ControllerBase
    {
        
        private readonly ILogger<UserController> _logger = logger;
        private readonly MyDBContext _dbContext = dbContext;

        [HttpGet(Name = "GetUsers")]
        public IEnumerable<User> Get()
        {
            return GetUsers();
           
        }

        private IEnumerable<User> GetUsers()
        {                       
            var userRepository = new UserRepository(_dbContext);

            return userRepository.GetUsers();

        }
    }
}
