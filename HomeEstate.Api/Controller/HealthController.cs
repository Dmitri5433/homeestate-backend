using Microsoft.AspNetCore.Mvc;

namespace HomeEstate.Api.Controller
{
    [Route("api/health")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { Status = "OK", Time = DateTime.UtcNow });
        }
    }
}
