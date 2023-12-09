using GreenThumb.Models;
using System.Linq;

namespace GreenThumb.Database
{
    internal class GreenThumbPlantRepository : GreenThumbRepository<Plant>
    {
        GreenThumbDbContext _context;

        public GreenThumbPlantRepository(GreenThumbDbContext context) : base(context)
        {
            _context = context;
        }

        public Plant? GetByName(string name)
        {
            return _context.Plants.Where(p => p.Name == name).FirstOrDefault();
        }
        // Checks if a plant already exists in the database, by its name property
        public bool PLantExists(string name)
        {
            if (_context.Plants.Where(p => p.Name == name).FirstOrDefault() != null)
            {
                return true;
            }
            return false;
        }
    }
}
