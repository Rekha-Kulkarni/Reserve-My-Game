using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reserve_My_Game.Model
{
    [Table("GameSessions")]
    public class GameSession
    {
        public int SessionId { get; set; }

        [Required]
        public int GameId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int MaxPlayers { get; set; }

        // Navigation
        public Game Game { get; set; }

        public ICollection<Booking> Bookings { get; set; }

    }
}
