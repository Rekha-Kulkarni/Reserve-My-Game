using Microsoft.EntityFrameworkCore;

namespace Reserve_My_Game.Services
{
    public interface IGameService
    {
        public List<string> GetGames();

        public List<string> GetCities(int gameId);
        public List<string> GetSubAreas(int cityId);

    }
}
