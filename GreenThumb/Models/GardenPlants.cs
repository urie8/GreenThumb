namespace GreenThumb.Models
{
    internal class GardenPlants
    {
        public int GardenId { get; set; }
        public Garden Garden { get; set; } = null!;
        public int PlantId { get; set; }
        public Plant Plant { get; set; } = null!;
    }
}
