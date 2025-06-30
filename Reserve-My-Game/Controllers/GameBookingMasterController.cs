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
        public GameBookingMasterController(GameBookingDbCotext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        [HttpGet("GetAllGames")]
        
        public List<Game> GetGames()
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
