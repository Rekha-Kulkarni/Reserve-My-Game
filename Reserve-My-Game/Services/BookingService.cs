using Microsoft.AspNetCore.Mvc;
using Reserve_My_Game.Model;

namespace Reserve_My_Game.Services
{
    public class BookingService
    {
        private readonly GameBookingDbCotext _context;
        public BookingService(GameBookingDbCotext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void CreateBooking([FromBody] BookingRequest request)
        {
        
            // validate IDs exist before saving
            var user = _context.UserDetails.FirstOrDefault(u => u.UserId == request.UserId);
            var game = _context.Games.FirstOrDefault(g => g.GameId == request.GameId);
            var city = _context.Cities.FirstOrDefault(c => c.CityId == request.CityId);
            var subArea = _context.SubAreas.FirstOrDefault(s => s.Id == request.SubAreaId);

            var booking = new Booking
            {
                UserId = request.UserId,
                GameId = request.GameId,
                CityId = request.CityId,
                PlaygroundId = request.PlaygroundId,
                SubAreaId = request.SubAreaId,
                SessionId = request.SessionId
            };

            _context.Bookings.Add(booking);
            _context.SaveChanges();
        }
        public void GetUserBookings(int userId)
        {
            var bookings = (from b in _context.Bookings
                            join g in _context.Games on b.GameId equals g.GameId
                            join c in _context.Cities on b.CityId equals c.CityId
                            join s in _context.SubAreas on b.SubAreaId equals s.Id
                            where b.UserId == userId
                            select new
                            {
                                b.BookingId,
                                b.BookingTime,
                                GameName = g.Title,
                                CityName = c.Name,
                                SubAreaName = s.Name
                            }).ToList();
        }

    }
    public class BookingRequest
    {
        public int UserId { get; set; }
        public int GameId { get; set; }
        public int CityId { get; set; }
        public int SubAreaId { get; set; }
        public int PlaygroundId { get; set; }
        public int SessionId { get; set; }
        public int Amount { get; set; }
    }

}
