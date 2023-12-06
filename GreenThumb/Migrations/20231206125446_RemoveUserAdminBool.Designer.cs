﻿// <auto-generated />
using GreenThumb.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GreenThumb.Migrations
{
    [DbContext(typeof(GreenThumbDbContext))]
    [Migration("20231206125446_RemoveUserAdminBool")]
    partial class RemoveUserAdminBool
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GreenThumb.Models.Garden", b =>
                {
                    b.Property<int>("GardenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GardenId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("GardenId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Gardens");
                });

            modelBuilder.Entity("GreenThumb.Models.GardenPlants", b =>
                {
                    b.Property<int>("GardenId")
                        .HasColumnType("int");

                    b.Property<int>("PlantId")
                        .HasColumnType("int");

                    b.HasKey("GardenId", "PlantId");

                    b.HasIndex("PlantId");

                    b.ToTable("GardenPlants");
                });

            modelBuilder.Entity("GreenThumb.Models.Instruction", b =>
                {
                    b.Property<int>("InstructionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InstructionId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InstructionType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlantId")
                        .HasColumnType("int");

                    b.HasKey("InstructionId");

                    b.HasIndex("PlantId");

                    b.ToTable("Instructions");

                    b.HasData(
                        new
                        {
                            InstructionId = 1,
                            Description = "Place your aloe vera where there is a lot of sunshine.",
                            InstructionType = "Light",
                            PlantId = 1
                        },
                        new
                        {
                            InstructionId = 2,
                            Description = "Water your aloe vera every two weeks, use water sparingly.",
                            InstructionType = "Water",
                            PlantId = 1
                        },
                        new
                        {
                            InstructionId = 3,
                            Description = "Aloe plants grow best in well-draining soil. Use commercial potting mix or make your own.",
                            InstructionType = "Soil",
                            PlantId = 1
                        },
                        new
                        {
                            InstructionId = 4,
                            Description = "Monstera Deliciosa thrives in bright, indirect light. It prefers not to be in direct sunlight, which can cause the leaves to scorch. In order to grow a plant near a south or west-facing window, the window should be shaded (e.g. with a curtain).",
                            InstructionType = "Light",
                            PlantId = 2
                        },
                        new
                        {
                            InstructionId = 5,
                            Description = "Check the soil moisture before watering your Monstera plant. Allow the soil to dry out slightly between waterings, as over-watering can lead to root rot. A general rule of thumb is to water your Monstera plant when the top 2-3 cm of the soil feels dry to the touch.",
                            InstructionType = "Water",
                            PlantId = 2
                        },
                        new
                        {
                            InstructionId = 6,
                            Description = "Monstera Deliciosa prefers a well-draining, slightly acidic soil with a pH of 6.0-6.5. A good soil mix for this plant might include equal parts potting soil, perlite, and peat moss.",
                            InstructionType = "Soil",
                            PlantId = 2
                        },
                        new
                        {
                            InstructionId = 7,
                            Description = "As the Areca Palms originally grow in tropical forests, under and between larger trees, it's happiest when placed in a bright spot that doesn't get direct sun on its leaves.",
                            InstructionType = "Light",
                            PlantId = 3
                        },
                        new
                        {
                            InstructionId = 8,
                            Description = "They don't tolerate overwatering, which can lead to root rot and other fungal diseases, and they also don't also like when their soil is allowed to dry out completely. It’s best to water it when half of the soil feels dry to the touch. You can check it by poking your finger into the soil or using a water meter.",
                            InstructionType = "Water",
                            PlantId = 3
                        },
                        new
                        {
                            InstructionId = 9,
                            Description = "For the best results, we suggest you try the PLNTS organic houseplant soil. You'll make your areca palms super happy with this!",
                            InstructionType = "Soil",
                            PlantId = 3
                        });
                });

            modelBuilder.Entity("GreenThumb.Models.Plant", b =>
                {
                    b.Property<int>("PlantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlantId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Family")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PlantId");

                    b.ToTable("Plants");

                    b.HasData(
                        new
                        {
                            PlantId = 1,
                            Description = "Aloe is a cactus-like plant that grows in hot, dry climates. It is cultivated in subtropical regions around the world, including the southern border areas of Texas, New Mexico, Arizona, and California.",
                            Family = "Asphodelaceae",
                            Name = "Aloe Vera"
                        },
                        new
                        {
                            PlantId = 2,
                            Description = "Monstera deliciosa, the Swiss cheese plant or split-leaf philodendron is a species of flowering plant native to tropical forests of southern Mexico, south to Panama.Monstera deliciosa is mainly cultivated for its large, glossy, dark green leaves that can reach up to one metre in length. The edges of the juvenile leaves are unbroken, but as the plant matures the leaf edges become deeply cut and have elliptic holes in them. There are also attractive variegated cultivars available with cream marbling to the leaves, which can brighten up a dark spot in a room or glasshouse, adding contrast to other tropical foliage.",
                            Family = "Araceae",
                            Name = "Monstera deliciosa"
                        },
                        new
                        {
                            PlantId = 3,
                            Description = "Dypsis lutescens also know as areca palm is a perennial tropical plant that grows to 6–12 m (20–39 ft) in height and spreads from 3-5 m (8-15ft). Multiple cane-like stems emerge from the base, creating a vase-like shape. The leaves are upward-arching, 2–3 m (6 ft 7 in – 9 ft 10 in) long, pinnate, with a yellow mid-rib.",
                            Family = "Arecaceae",
                            Name = "Dypsis lutescens"
                        });
                });

            modelBuilder.Entity("GreenThumb.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GreenThumb.Models.Garden", b =>
                {
                    b.HasOne("GreenThumb.Models.User", "User")
                        .WithOne("Garden")
                        .HasForeignKey("GreenThumb.Models.Garden", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("GreenThumb.Models.GardenPlants", b =>
                {
                    b.HasOne("GreenThumb.Models.Garden", "Garden")
                        .WithMany("GardenPlants")
                        .HasForeignKey("GardenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GreenThumb.Models.Plant", "Plant")
                        .WithMany()
                        .HasForeignKey("PlantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Garden");

                    b.Navigation("Plant");
                });

            modelBuilder.Entity("GreenThumb.Models.Instruction", b =>
                {
                    b.HasOne("GreenThumb.Models.Plant", "Plant")
                        .WithMany("Instructions")
                        .HasForeignKey("PlantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plant");
                });

            modelBuilder.Entity("GreenThumb.Models.Garden", b =>
                {
                    b.Navigation("GardenPlants");
                });

            modelBuilder.Entity("GreenThumb.Models.Plant", b =>
                {
                    b.Navigation("Instructions");
                });

            modelBuilder.Entity("GreenThumb.Models.User", b =>
                {
                    b.Navigation("Garden");
                });
#pragma warning restore 612, 618
        }
    }
}
