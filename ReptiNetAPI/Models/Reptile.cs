namespace ReptiNetAPI.Models
{
    public class Reptile
    {
        public int ID { get; set; }
        public required string Name { get; set; }
        public required string Species { get; set; }
        public string? Clutch { get; set; } = null;

    }
}
