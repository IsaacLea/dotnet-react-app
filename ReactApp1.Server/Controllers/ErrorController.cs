using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ReactApp1.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ErrorController(ILogger<UserController> logger, IMapper mapper) : ControllerBase
    {
        private readonly ILogger<UserController> _logger = logger;

        [Route("/error")]
        [ApiExplorerSettings(IgnoreApi = true)] // Ignore this controller when swagger scans for APIs
        public IActionResult HandleError() =>
            Problem();
    }
}
