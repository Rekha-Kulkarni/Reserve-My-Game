using System.ComponentModel.DataAnnotations;

namespace Reserve_My_Game.Model
{
    public class Games
    {
        public int GameId { get; set; }

        [Required, MaxLength(100)]
        public string Title { get; set; }

        public string Description { get; set; }

        public int TotalSlots { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public ICollection<GameSessions> GameSessions { get; set; }
    }

}
