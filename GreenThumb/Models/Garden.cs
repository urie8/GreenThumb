using System.Collections.Generic;

namespace GreenThumb.Models
{
    internal class Garden
    {
        public int GardenId { get; set; }
        public string Name { get; set; } = null!;
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public List<GardenPlants> GardenPlants { get; set; } = new();

    }
}
