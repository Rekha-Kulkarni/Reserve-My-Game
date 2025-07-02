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

        public List<string> GetGames()
        {
            var list = new List<string>() {"Pickelball","Cricket","Football","Tennis","Table Tennis","Volleyball"};
            return list;
        }

        [HttpGet("GetAllCities")]
        public List<string> GetCities()
        {
            var list = new List<string>() { "Pune", "Mumbai", "banglore", "Chennai", "AhmedNagar" };
            return list;
        }

    }
}
