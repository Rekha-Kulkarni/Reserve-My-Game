using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reserve_My_Game.Model;

namespace Reserve_My_Game.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly GameBookingDbCotext _context;
        public UserController(GameBookingDbCotext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        [HttpPost("AddUser")]
        public IActionResult AddUserDetails(UserDetails user)
        {
            var userExists = _context.UserDetails.SingleOrDefault(y => y.EmailId == user.EmailId);
            if (userExists == null)
            {
                _context.UserDetails.Add(user);
                _context.SaveChanges();
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
            var user = _context.UserDetails.SingleOrDefault(x => x.EmailId == userLogin.emailId);
            if (user == null)
                return StatusCode(401, "wrong credentials");
            else
                return StatusCode(200, user);
        }
    }
}
