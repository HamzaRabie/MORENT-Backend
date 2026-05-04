namespace MORENT.Models
{
    public class Car
    {
        public Guid Id { get; set; }
        public string Brand { get; set; } = string.Empty!;
        public string Model { get; set; } = string.Empty!;
        public string Category { get; set; } = string.Empty!;
        public decimal PricePerDay { get; set; }
        public string ImageUrl { get; set; } = string.Empty!;
        public bool IsAvailable { get; set; }
    }
}
