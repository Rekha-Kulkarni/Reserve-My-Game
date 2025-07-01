using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reserve_My_Game.Model
{
    public class UserDetails
    {
        [Key]
        public int UserId { get; set; }

        [Required, MaxLength(100)]
        public string UserName  { get; set; }

        [Required, EmailAddress, MaxLength(100)]
        public string EmailId    { get; set; }
        public string City { get; set; }
        [Required, MaxLength(100)]
        public string MobileNo { get; set; }
        public string Address { get; set; }

        [Required, MaxLength(100)]
        public string Password { get; set; }

    }


}
