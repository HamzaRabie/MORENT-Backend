namespace MORENT.Dtos
{
    public class GetBookingDto
    {
        public string CarName { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public DateTime PickUpDate { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
