namespace MORENT.Dtos
{
    public record GetCarDetailsDto
    {
        public Guid Id { get; set; }
        public string Brand { get; set; } = string.Empty!;
        public string Model { get; set; } = string.Empty!;
        public string Category { get; set; } = string.Empty!;
        public decimal PricePerDay { get; set; }
        public decimal? OriginalPrice { get; set; }
        public string ImageUrl { get; set; } = string.Empty!;
        public List<string> Images { get; set; } = new(); // gallery thumbnails
        public bool IsAvailable { get; set; }
        public int Seats { get; set; }
        public string FuelType { get; set; } = string.Empty;
        public int FuelCapacity { get; set; }
        public string Transmission { get; set; } = string.Empty;
        public bool IsFavorite { get; set; }
        public string Description { get; set; } = string.Empty; // hero text
        public double Rating { get; set; }                      // star rating
        public int ReviewCount { get; set; }                    // "440+ Reviewer"
        public List<ReviewDto> Reviews { get; set; } = new();   // reviews section
    }


    public record ReviewDto
    {
        public string Id { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string UserRole { get; set; } = string.Empty;
        public string UserAvatar { get; set; } = string.Empty;
        public int Rating { get; set; }
        public string Comment { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
