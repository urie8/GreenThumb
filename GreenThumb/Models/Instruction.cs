namespace GreenThumb.Models
{
    public class Instruction
    {
        public int InstructionId { get; set; }
        public string InstructionType { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int PlantId { get; set; }
        public Plant Plant { get; set; } = null!;
    }
}
