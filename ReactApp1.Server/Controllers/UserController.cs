using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReactApp1.Server.DTO;
using ReactApp1.Server.Service;

namespace ReactApp1.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController(ILogger<UserController> logger, IMapper mapper, IUserService userService) : ControllerBase
    {
        private readonly ILogger<UserController> _logger = logger;
        private readonly IMapper _mapper = mapper;
        private readonly IUserService _userService = userService;

        [HttpGet(Name = "GetUsers")]
        public IEnumerable<UserDTO> Get()
        {
            return _userService.GetUsers().GetAwaiter().GetResult();
        }

        // POST: /User
        [HttpPost]
        public IActionResult Post([FromBody] UserDTO userDTO)
        {
            if (userDTO == null)
            {
                return BadRequest("User data is required.");
            }

            _userService.AddUser(userDTO);

            return CreatedAtRoute("GetUsers", null, userDTO);

            //var userRepository = new UserRepository(_dbContext);
            //user.CreateAt = DateTime.UtcNow;
            //userRepository.AddUser(user);

            //return CreatedAtRoute("GetUsers", new { id = user.Id }, user);
        }
    }
}
