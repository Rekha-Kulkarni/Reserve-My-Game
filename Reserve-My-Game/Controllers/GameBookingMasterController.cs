using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reserve_My_Game.Model;
using Reserve_My_Game.Services;

namespace Reserve_My_Game.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameBookingMasterController : ControllerBase
    {
        private readonly IGameService _gameService;
        public GameBookingMasterController(IGameService gameService)
        {
            _gameService = gameService;
        }


        [HttpGet("GetAllGames")]

        public List<string> GetGames()
        {
            var list = _gameService.GetGames();
            return list;
        }

        [HttpGet("GetAllCities/{gameId}")]
        public IActionResult GetCities(int gameId)
        {
            var cities = _gameService.GetCities(gameId);

            if (cities == null || !cities.Any())
                return NotFound("No cities found for this game.");

            return Ok(cities);
        }

        [HttpGet("GetAllSubAreas/{cityId}")]
        public IActionResult GetSubAreas(int cityId)
        {
            var subAreas = _gameService.GetSubAreas(cityId);

            if (subAreas == null || !subAreas.Any())
                return NotFound("No sub-areas found for this city.");

            return Ok(subAreas);
        }
    }
}
