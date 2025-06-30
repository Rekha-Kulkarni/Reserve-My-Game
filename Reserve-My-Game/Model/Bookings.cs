using System.ComponentModel.DataAnnotations;

namespace Reserve_My_Game.Model
{
    public class Bookings
    {
        public int BookingId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int SessionId { get; set; }

        public DateTime BookingTime { get; set; } = DateTime.UtcNow;

        // Navigation
        public UserDetails User { get; set; }
    }
}
