using Reserve_My_Game.Model;

namespace Reserve_My_Game.Services
{
    public class UserService : IUserService
    {
        private readonly GameBookingDbCotext _context;
        public UserService(GameBookingDbCotext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public bool AddUserDetails(UserDetails user)
        {
            var userExists = _context.UserDetails.SingleOrDefault(y => y.EmailId == user.EmailId);
            if (userExists == null)
            {
                _context.UserDetails.Add(user);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Login(UserLogin userLogin)
        {
            var user = _context.UserDetails.SingleOrDefault(x => x.EmailId == userLogin.emailId);
            if (user == null)
                return false;
            else
                return true;
        }
    }
}
