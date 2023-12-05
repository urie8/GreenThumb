using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenThumb.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    PlantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Family = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.PlantId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Instructions",
                columns: table => new
                {
                    InstructionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstructionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructions", x => x.InstructionId);
                    table.ForeignKey(
                        name: "FK_Instructions_Plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plants",
                        principalColumn: "PlantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gardens",
                columns: table => new
                {
                    GardenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gardens", x => x.GardenId);
                    table.ForeignKey(
                        name: "FK_Gardens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GardenPlants",
                columns: table => new
                {
                    GardenId = table.Column<int>(type: "int", nullable: false),
                    PlantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GardenPlants", x => new { x.GardenId, x.PlantId });
                    table.ForeignKey(
                        name: "FK_GardenPlants_Gardens_GardenId",
                        column: x => x.GardenId,
                        principalTable: "Gardens",
                        principalColumn: "GardenId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GardenPlants_Plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plants",
                        principalColumn: "PlantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Plants",
                columns: new[] { "PlantId", "Description", "Family", "Name" },
                values: new object[] { 1, "Aloe is a cactus-like plant that grows in hot, dry climates. It is cultivated in subtropical regions around the world, including the southern border areas of Texas, New Mexico, Arizona, and California.", "Asphodelaceae", "Aloe Vera" });

            migrationBuilder.InsertData(
                table: "Plants",
                columns: new[] { "PlantId", "Description", "Family", "Name" },
                values: new object[] { 2, "Monstera deliciosa, the Swiss cheese plant or split-leaf philodendron is a species of flowering plant native to tropical forests of southern Mexico, south to Panama.Monstera deliciosa is mainly cultivated for its large, glossy, dark green leaves that can reach up to one metre in length. The edges of the juvenile leaves are unbroken, but as the plant matures the leaf edges become deeply cut and have elliptic holes in them. There are also attractive variegated cultivars available with cream marbling to the leaves, which can brighten up a dark spot in a room or glasshouse, adding contrast to other tropical foliage.", "Araceae", "Monstera deliciosa" });

            migrationBuilder.InsertData(
                table: "Plants",
                columns: new[] { "PlantId", "Description", "Family", "Name" },
                values: new object[] { 3, "Dypsis lutescens also know as areca palm is a perennial tropical plant that grows to 6–12 m (20–39 ft) in height and spreads from 3-5 m (8-15ft). Multiple cane-like stems emerge from the base, creating a vase-like shape. The leaves are upward-arching, 2–3 m (6 ft 7 in – 9 ft 10 in) long, pinnate, with a yellow mid-rib.", "Arecaceae", "Dypsis lutescens" });

            migrationBuilder.InsertData(
                table: "Instructions",
                columns: new[] { "InstructionId", "Description", "InstructionType", "PlantId" },
                values: new object[,]
                {
                    { 1, "Place your aloe vera where there is a lot of sunshine.", "Light", 1 },
                    { 2, "Water your aloe vera every two weeks, use water sparingly.", "Water", 1 },
                    { 3, "Aloe plants grow best in well-draining soil. Use commercial potting mix or make your own.", "Soil", 1 },
                    { 4, "Monstera Deliciosa thrives in bright, indirect light. It prefers not to be in direct sunlight, which can cause the leaves to scorch. In order to grow a plant near a south or west-facing window, the window should be shaded (e.g. with a curtain).", "Light", 2 },
                    { 5, "Check the soil moisture before watering your Monstera plant. Allow the soil to dry out slightly between waterings, as over-watering can lead to root rot. A general rule of thumb is to water your Monstera plant when the top 2-3 cm of the soil feels dry to the touch.", "Water", 2 },
                    { 6, "Monstera Deliciosa prefers a well-draining, slightly acidic soil with a pH of 6.0-6.5. A good soil mix for this plant might include equal parts potting soil, perlite, and peat moss.", "Soil", 2 },
                    { 7, "As the Areca Palms originally grow in tropical forests, under and between larger trees, it's happiest when placed in a bright spot that doesn't get direct sun on its leaves.", "Light", 3 },
                    { 8, "They don't tolerate overwatering, which can lead to root rot and other fungal diseases, and they also don't also like when their soil is allowed to dry out completely. It’s best to water it when half of the soil feels dry to the touch. You can check it by poking your finger into the soil or using a water meter.", "Water", 3 },
                    { 9, "For the best results, we suggest you try the PLNTS organic houseplant soil. You'll make your areca palms super happy with this!", "Soil", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GardenPlants_PlantId",
                table: "GardenPlants",
                column: "PlantId");

            migrationBuilder.CreateIndex(
                name: "IX_Gardens_UserId",
                table: "Gardens",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Instructions_PlantId",
                table: "Instructions",
                column: "PlantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GardenPlants");

            migrationBuilder.DropTable(
                name: "Instructions");

            migrationBuilder.DropTable(
                name: "Gardens");

            migrationBuilder.DropTable(
                name: "Plants");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
