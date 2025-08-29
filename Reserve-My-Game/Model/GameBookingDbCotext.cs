using Microsoft.EntityFrameworkCore;

namespace Reserve_My_Game.Model
{
    public class GameBookingDbCotext : DbContext
    {
        public GameBookingDbCotext(DbContextOptions<GameBookingDbCotext> options) : base(options) { }
        public DbSet<UserDetails> UserDetails { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<City> Cities { get; set; }

        public DbSet<SubArea> SubAreas { get; set; }
        public DbSet<GameSession> GameSessions { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameSession>()
                .HasKey(gs => gs.SessionId);
            modelBuilder.Entity<UserDetails>().HasKey(u => u.UserId);
        }
   
    }
}
