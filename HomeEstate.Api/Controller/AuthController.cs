using HomeEstate.BusinessLogic.Interface;
using HomeEstate.Domains.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace HomeEstate.Api.Controller
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserRegisterDto data) =>
            Ok(_authService.Register(data));

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginDto data)
        {
            var session = _authService.Login(data);
            if (session == null)
                return Unauthorized(new { IsSuccess = false, Message = "Invalid email or password." });

            Response.Cookies.Append("session_token", session.SessionToken, new CookieOptions
            {
                HttpOnly = true,
                SameSite = SameSiteMode.None,
                Secure = true,
                Expires = DateTimeOffset.UtcNow.AddDays(7)
            });

            return Ok(session);
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            var token = Request.Cookies["session_token"];
            if (string.IsNullOrEmpty(token))
                return Ok(new { IsSuccess = true, Message = "Already logged out." });

            var result = _authService.Logout(token);
            Response.Cookies.Delete("session_token");

            return Ok(result);
        }

        [HttpGet("session")]
        public IActionResult GetSession()
        {
            var token = Request.Cookies["session_token"];
            if (string.IsNullOrEmpty(token))
                return Unauthorized(new { IsSuccess = false, Message = "No active session." });

            var session = _authService.GetSession(token);
            if (session == null)
                return Unauthorized(new { IsSuccess = false, Message = "Session expired." });

            return Ok(session);
        }

        [HttpGet("users")]
        public IActionResult GetAllUsers() =>
            Ok(_authService.GetAllUsers());
    }
}