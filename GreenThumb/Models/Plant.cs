using System.Collections.Generic;

namespace GreenThumb.Models
{
    public class Plant
    {
        public int PlantId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Family { get; set; } = null!;
        public List<Instruction> Instructions { get; set; } = new();
    }
}