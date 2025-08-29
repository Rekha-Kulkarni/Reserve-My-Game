using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reserve_My_Game.Model;
using Reserve_My_Game.Services;

namespace Reserve_My_Game.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly GameBookingDbCotext _context;
        private readonly IUserService _userService;
        public UserController(GameBookingDbCotext context, IUserService userService)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
           _userService = userService;
        }
        [HttpPost("AddUser")]
        public IActionResult AddUserDetails(UserDetails user)
        {
            var success = _userService.AddUserDetails(user);
            if (success)
            {
                return Created("User Added", user);
            }
            else
            {
                return StatusCode(500, "EmailId already exists");
            }
        }
        [HttpPost("Login")]
        public IActionResult Login(UserLogin userLogin)
        {
            var user = _userService.Login(userLogin);
            if (!user)
                return StatusCode(401, "wrong credentials");
            else
                return StatusCode(200, user);
        }
    }
}
