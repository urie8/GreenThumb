using GreenThumb.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace GreenThumb.Database
{
    internal class GreenThumbGardenPlantsRepository : GreenThumbRepository<GardenPlants>
    {
        GreenThumbDbContext _context;
        public GreenThumbGardenPlantsRepository(GreenThumbDbContext context) : base(context)
        {
            _context = context;
        }

        // Get a list of gardens by id input, including all the plants
        public List<GardenPlants> GetByGardenIdWithPlants(int id)
        {
            return _context.GardenPlants.Include(gp => gp.Plant).Where(gp => gp.GardenId == id).ToList();
        }
    }
}
