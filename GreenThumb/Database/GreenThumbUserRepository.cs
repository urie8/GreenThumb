using GreenThumb.Models;

namespace GreenThumb.Database
{
    internal class GreenThumbUserRepository : GreenThumbRepository<User>
    {
        GreenThumbDbContext _context;
        public User SignedInUser { get; set; }
        public GreenThumbUserRepository(GreenThumbDbContext context) : base(context)
        {
            _context = context;
        }

        public bool ValidateUsername(string username)
        {
            bool isValidUsername = true;
            foreach (var user in _context.Users)
            {
                if (user.Username == username)
                {
                    isValidUsername = false;
                }
            }
            return isValidUsername;
        }

        public bool SignInUser(string username, string password)
        {
            foreach (var user in _context.Users)
            {
                if (user.Username == username && user.Password == password)
                {
                    SignedInUser = user;
                    return true;
                }
            }
            return false;
        }
    }
}
