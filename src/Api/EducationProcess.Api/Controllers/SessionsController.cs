using System.Net;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using EducationProcess.Api.Security;
using Microsoft.Extensions.Logging;

namespace EducationProcess.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionsController : ControllerBase
    {
        private readonly ILogger<SessionsController> _logger;
        private readonly IJwtGenerator _jwtGenerator;

        public SessionsController(ILogger<SessionsController> logger, IJwtGenerator jwtGenerator)
        {
            _logger = logger;
            _jwtGenerator = jwtGenerator;
        }

        [HttpPost("login")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Login([FromBody] string username)
        {
            string token = _jwtGenerator.CreateToken(username);
            return Ok(token);
        }

        [HttpPost("register")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Register([FromBody] string username)
        {
            return null;
        }
    }
}
