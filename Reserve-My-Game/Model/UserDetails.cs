using System.ComponentModel.DataAnnotations;

namespace Reserve_My_Game.Model
{
    public class UserDetails
    {
        public int UserId { get; set; }

        [Required, MaxLength(100)]
        public string UserName  { get; set; }

        [Required, EmailAddress, MaxLength(100)]
        public string EmailId    { get; set; }

        [Required, MaxLength(100)]
        public string City { get; set; }
        [Required, MaxLength(100)]
        public string MobileNo { get; set; }
        [Required, MaxLength(100)]
        public string Address { get; set; }

        // Navigation
        public ICollection<Bookings> Bookings { get; set; }
    }


}
