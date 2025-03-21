using CheckListBuild_BE.DTOs;
using CheckListBuild_BE.Entities;
using CheckListBuild_BE.service;
using Microsoft.AspNetCore.Mvc;

namespace CheckListBuild_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] AuthenticateRequestModel user)
        {
            var authUser = _authService.Authenticate(user.Username, user.Password);
            if (authUser == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }
            var token = _authService.GenerateJwtToken(authUser);
            return Ok(new { token });
        }

    }
}
