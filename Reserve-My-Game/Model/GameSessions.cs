using System.ComponentModel.DataAnnotations;

namespace Reserve_My_Game.Model
{
    public class GameSessions
    {
        public int SessionId { get; set; }

        [Required]
        public int GameId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int MaxPlayers { get; set; }

        // Navigation
        public Games Game { get; set; }

        public ICollection<Bookings> Bookings { get; set; }

    }
}
