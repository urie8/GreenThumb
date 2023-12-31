﻿using GreenThumb.Models;
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

        // Get a specific garden plant by its garden id and plant id
        public GardenPlants? GetByGardenAndPlantId(int gardenId, int plantId)
        {
            return _context.GardenPlants.Where(gp => gp.GardenId == gardenId && gp.PlantId == plantId).FirstOrDefault();
        }

        // Get a specific garden plant by its garden id and plant id including plant info
        public GardenPlants? GetByGardenAndPlantIdIncludePlants(int gardenId, int plantId)
        {
            return _context.GardenPlants.Include(gp => gp.Plant).Where(gp => gp.GardenId == gardenId && gp.PlantId == plantId).FirstOrDefault();
        }

        // Checks if a specific gardenplant exists in the database, by its garden id and plant id
        public bool GardenPlantExists(int gardenId, int plantId)
        {
            if (_context.GardenPlants.Where(gp => gp.GardenId == gardenId && gp.PlantId == plantId).FirstOrDefault() != null)
            {
                return true;
            }
            return false;
        }
    }
}
