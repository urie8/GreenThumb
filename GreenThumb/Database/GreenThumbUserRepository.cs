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
        // Checks if there are any users with the same name in the database
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
        // Checks if the combination of username and password exists in the database and sets the current user to that user
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
