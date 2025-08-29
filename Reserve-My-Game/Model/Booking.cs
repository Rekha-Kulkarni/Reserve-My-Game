using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reserve_My_Game.Model
{
    [Table("Bookings")]
    public class Booking
    {
        public int BookingId { get; set; }

        [Required]
        public int UserId { get; set; }
        public int GameId { get; set; }
        public int CityId { get; set; }
        public int SubAreaId { get; set; }

        public int PlaygroundId { get; set; }


        [Required]
        public int SessionId { get; set; }

        public DateTime BookingTime { get; set; } = DateTime.UtcNow;

        // Navigation
        public UserDetails User { get; set; }
    }
}
