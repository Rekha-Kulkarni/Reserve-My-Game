using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reserve_My_Game.Model
{
    [Table("Games")]
    public class Game
    {
        public int GameId { get; set; }

        [Required, MaxLength(100)]
        public string Title { get; set; }

        public string Description { get; set; }

        public int TotalSlots { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public ICollection<GameSession> GameSessions { get; set; }
    }

}
