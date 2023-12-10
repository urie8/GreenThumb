using GreenThumb.Models;
using System.Collections.Generic;
using System.Linq;

namespace GreenThumb.Database
{
    internal class GreenThumbInstructionRepository : GreenThumbRepository<Instruction>
    {
        GreenThumbDbContext _context;

        public GreenThumbInstructionRepository(GreenThumbDbContext context) : base(context)
        {
            _context = context;
        }

        // Get a list of instructions from a specific plant
        public List<Instruction> GetAllWithPlantId(int id)
        {
            return _context.Instructions.Where(i => i.PlantId == id).ToList();
        }
    }
}
