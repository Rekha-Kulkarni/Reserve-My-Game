using Microsoft.EntityFrameworkCore;

namespace Reserve_My_Game.Model
{
    public class GameBookingDbCotext : DbContext
    {
        public GameBookingDbCotext(DbContextOptions<GameBookingDbCotext> options) : base(options) { }
        public DbSet<UserDetails> UserDetails { get; set; }
        public DbSet<Games> Games { get; set; }
        public DbSet<GameSessions> GameSessions { get; set; }
        public DbSet<Bookings> Bookings { get; set; }
    }
}
