using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SinglePageApp.Api.Services;
using SinglePageApp.Models;

namespace SinglePageApp.Controller
{

    [ApiController]
    public class UserController
    {
        [Route("api/[controller]")]
        public class UsersController : ControllerBase
        {
            private IUserService _userService;

            public UsersController(IUserService userService)
            {
                _userService = userService;
            }

            [HttpPost("authenticate")]
            public IActionResult Authenticate(AuthenticateRequest model)
            {
                var response = _userService.Authenticate(model);

                if (response == null)
                    return BadRequest(new { message = "Username or password is incorrect" });

                return Ok(response);
            }

            [Authorize]
            [HttpGet]
            public IActionResult GetAll()
            {
                var users = _userService.GetAll();
                return Ok(users);
            }
        }
    }
}
