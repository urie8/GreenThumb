namespace GreenThumb.Database
{
    internal class GreenThumbUow
    {
        private readonly GreenThumbDbContext _context;

        public GreenThumbUserRepository UserRepository { get; }
        public GreenThumbGardenRepository GardenRepository { get; }
        public GreenThumbPlantRepository PlantRepository { get; }
        public GreenThumbInstructionRepository InstructionRepository { get; }
        public GreenThumbGardenPlantsRepository GardenPlantsRepository { get; }

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
