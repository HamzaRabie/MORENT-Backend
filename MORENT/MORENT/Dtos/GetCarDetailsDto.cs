namespace MORENT.Dtos
{
    public record GetCarDetailsDto
    {
        public  string Id { get; set; } = string.Empty!;
        public string Brand { get; set; } = string.Empty!;
        public string Model { get; set; } = string.Empty!;
        public string Category { get; set; } = string.Empty!;
        public decimal PricePerDay { get; set; }
        public string ImageUrl { get; set; } = string.Empty!;
        public bool IsAvailable { get; set; }
        public decimal? OriginalPrice { get; set; }
        public int Seats { get; set; }
        public string FuelType { get; set; } = string.Empty;
        public int FuelCapacity { get; set; }
        public string Transmission { get; set; } = string.Empty;
        public bool IsFavorite { get; set; }
    }
}
