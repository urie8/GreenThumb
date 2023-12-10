using GreenThumb.Models;
using System.Linq;

namespace GreenThumb.Database
{
    internal class GreenThumbGardenRepository : GreenThumbRepository<Garden>
    {
        GreenThumbDbContext _context;
        public GreenThumbGardenRepository(GreenThumbDbContext context) : base(context)
        {
            _context = context;
        }

        // Get a specific garden by a specific user
        public Garden? GetByUserId(int id)
        {
            return _context.Gardens.Where(g => g.UserId == id).FirstOrDefault();
        }
    }
}
