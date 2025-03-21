using CheckListBuild_BE.Entities;
using CheckListBuild_BE.service;
using Microsoft.AspNetCore.Mvc;

namespace CheckListBuild_BE.Controllers
{
    [Route("api/user/")]
    [ApiController]
    public class UserController : ControllerBase
    {
            private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("User no empty");
            }
            await _userService.Create(user);
            return Ok("Added Successfully");
        }

        [HttpGet("get")]
        public async Task<ActionResult<List<User>>> Get()
        {
            return await _userService.GetAll();
        }
    }
}
