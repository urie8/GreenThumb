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
    }
}
