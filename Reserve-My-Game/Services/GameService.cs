using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reserve_My_Game.Model;

namespace Reserve_My_Game.Services
{
    public class GameService : IGameService
    {
        private readonly GameBookingDbCotext _context;
        public GameService(GameBookingDbCotext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public List<string> GetGames()
        {
            var list = new List<string>() { "Pickelball", "Cricket", "Football", "Tennis", "Table Tennis", "Volleyball" };
            return list;
        }
        public List<string> GetCities(int gameId)
        {
            var cities = _context.Cities
                                 .Where(x => x.GameId == gameId)
                                 .Select(x => x.Name)   // assuming your City entity has a Name property
                                 .ToList();

            if (cities == null || !cities.Any())
                return null;

            return cities;
        }
        public List<string> GetSubAreas(int cityId)
        {
            var subAreas = _context.SubAreas
                                   .Where(x => x.CityId == cityId)
                                   .Select(x => x.Name)   // assuming your SubArea entity has a Name property
                                   .ToList();

            if (subAreas == null || !subAreas.Any())
                return null;

            return subAreas;
        }
    }
}
