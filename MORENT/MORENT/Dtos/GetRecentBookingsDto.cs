namespace MORENT.Dtos
{
    public record GetRecentBookingsDto
    {
        public string CarName { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public DateTime PickupDate { get; set; }
        public decimal TotalPrice { get; set; }

    }
}
