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
        public GardenPlants? GetByGardenAndPlantId(int gardenId, int plantId)
        {
            return _context.GardenPlants.Where(gp => gp.GardenId == gardenId && gp.PlantId == plantId).FirstOrDefault();
        }
        public void DeleteGardenPlant(GardenPlants gardenPlant)
        {
            _context.GardenPlants.Remove(gardenPlant);
        }
    }
}
