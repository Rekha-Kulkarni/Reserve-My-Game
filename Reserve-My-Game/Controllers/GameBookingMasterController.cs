using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reserve_My_Game.Model;

namespace Reserve_My_Game.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameBookingMasterController : ControllerBase
    {
        private readonly GameBookingDbCotext _context;

        [HttpGet("GetAllGames")]
        
        public List<Games> GetGames()
        {
            var list = _context.Games.ToList();
            return list;
        }
        [HttpPost("AddUser")]
        public UserDetails AddUserDetails(UserDetails user)
        {
           _context.UserDetails.Add(user);
            _context.SaveChanges();
            return user;
        }
    }
}
