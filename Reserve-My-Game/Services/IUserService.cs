using Reserve_My_Game.Model;

namespace Reserve_My_Game.Services
{
    public interface IUserService
    {
        public bool AddUserDetails(UserDetails user);
        public bool Login(UserLogin user);
    }
}
