using EntityFrameworkCore.EncryptColumn.Extension;
using EntityFrameworkCore.EncryptColumn.Interfaces;
using EntityFrameworkCore.EncryptColumn.Util;
using GreenThumb.Models;
using Microsoft.EntityFrameworkCore;

namespace GreenThumb.Database
{
    internal class GreenThumbDbContext : DbContext
    {
        private readonly IEncryptionProvider _provider;
        public GreenThumbDbContext()
        {
            _provider = new GenerateEncryptionProvider("xxxxxxxxxxxxxxxxxxxxxxxx");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Garden> Gardens { get; set; }
        public DbSet<Plant> Plants { get; set; }
        public DbSet<Instruction> Instructions { get; set; }
        public DbSet<GardenPlants> GardenPlants { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=GreenThumbDb;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<GardenPlants>().HasKey(gp => new { gp.GardenId, gp.PlantId });
            modelBuilder.UseEncryption(_provider);
            modelBuilder.Entity<Plant>()
                .HasData(
                new Plant()
                {
                    PlantId = 1,
                    Name = "Aloe Vera",
                    Description = "Aloe is a cactus-like plant that grows in hot, dry climates. It is cultivated in subtropical regions around the world, including the southern border areas of Texas, New Mexico, Arizona, and California.",
                    Family = "Asphodelaceae",

                },
                new Plant()
                {
                    PlantId = 2,
                    Name = "Monstera deliciosa",
                    Description = "Monstera deliciosa, the Swiss cheese plant or split-leaf philodendron is a species of flowering plant native to tropical forests of southern Mexico, south to Panama." +
                    "Monstera deliciosa is mainly cultivated for its large, glossy, dark green leaves that can reach up to one metre in length. The edges of the juvenile leaves are unbroken, but as the plant matures the leaf edges become deeply cut and have elliptic holes in them. There are also attractive variegated cultivars available with cream marbling to the leaves, which can brighten up a dark spot in a room or glasshouse, adding contrast to other tropical foliage.",
                    Family = "Araceae"

                },

                new Plant()
                {
                    PlantId = 3,
                    Name = "Dypsis lutescens",
                    Description = "Dypsis lutescens also know as areca palm is a perennial tropical plant that grows to 6–12 m (20–39 ft) in height and spreads from 3-5 m (8-15ft). Multiple cane-like stems emerge from the base, creating a vase-like shape. The leaves are upward-arching, 2–3 m (6 ft 7 in – 9 ft 10 in) long, pinnate, with a yellow mid-rib.",
                    Family = "Arecaceae"
                });

            modelBuilder.Entity<Instruction>()
                .HasData(
                new Instruction()
                {
                    InstructionId = 1,
                    InstructionType = "Light",
                    Description = "Place your aloe vera where there is a lot of sunshine.",
                    PlantId = 1
                },
                new Instruction()
                {
                    InstructionId = 2,
                    InstructionType = "Water",
                    Description = "Water your aloe vera every two weeks, use water sparingly.",
                    PlantId = 1
                },
                new Instruction()
                {
                    InstructionId = 3,
                    InstructionType = "Soil",
                    Description = "Aloe plants grow best in well-draining soil. Use commercial potting mix or make your own.",
                    PlantId = 1
                },
                new Instruction()
                {
                    InstructionId = 4,
                    InstructionType = "Light",
                    Description = "Monstera Deliciosa thrives in bright, indirect light. It prefers not to be in direct sunlight, which can cause the leaves to scorch. In order to grow a plant near a south or west-facing window, the window should be shaded (e.g. with a curtain).",
                    PlantId = 2
                },
                new Instruction()
                {
                    InstructionId = 5,
                    InstructionType = "Water",
                    Description = "Check the soil moisture before watering your Monstera plant. Allow the soil to dry out slightly between waterings, as over-watering can lead to root rot. A general rule of thumb is to water your Monstera plant when the top 2-3 cm of the soil feels dry to the touch.",
                    PlantId = 2
                },
                new Instruction()
                {
                    InstructionId = 6,
                    InstructionType = "Soil",
                    Description = "Monstera Deliciosa prefers a well-draining, slightly acidic soil with a pH of 6.0-6.5. A good soil mix for this plant might include equal parts potting soil, perlite, and peat moss.",
                    PlantId = 2
                },
                new Instruction()
                {
                    InstructionId = 7,
                    InstructionType = "Light",
                    Description = "As the Areca Palms originally grow in tropical forests, under and between larger trees, it's happiest when placed in a bright spot that doesn't get direct sun on its leaves.",
                    PlantId = 3
                },
                new Instruction()
                {
                    InstructionId = 8,
                    InstructionType = "Water",
                    Description = "They don't tolerate overwatering, which can lead to root rot and other fungal diseases, and they also don't also like when their soil is allowed to dry out completely. It’s best to water it when half of the soil feels dry to the touch. You can check it by poking your finger into the soil or using a water meter.",
                    PlantId = 3
                },
                new Instruction()
                {
                    InstructionId = 9,
                    InstructionType = "Soil",
                    Description = "For the best results, we suggest you try the PLNTS organic houseplant soil. You'll make your areca palms super happy with this!",
                    PlantId = 3
                });
        }
    }
}