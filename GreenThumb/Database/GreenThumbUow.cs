using GreenThumb.Models;

namespace GreenThumb.Database
{
    internal class GreenThumbUow
    {
        private readonly GreenThumbDbContext _context;

        public GreenThumbRepository<User> UserRepository { get; }
        public GreenThumbRepository<Garden> GardenRepository { get; }
        public GreenThumbRepository<Plant> PlantRepository { get; }
        public GreenThumbRepository<Instruction> InstructionRepository { get; }
        public GreenThumbRepository<GardenPlants> GardenPlantsRepository { get; }

        public GreenThumbUow(GreenThumbDbContext context)
        {
            _context = context;
            UserRepository = new(context);
            GardenRepository = new(context);
            PlantRepository = new(context);
            InstructionRepository = new(context);
            GardenPlantsRepository = new(context);

        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}
