using System.Text.Json.Serialization;

namespace MORENT.Dtos
{
    public record GetBookingDto
    {
        public string CarName { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        [JsonIgnore]
        public string Status { get; set; } = string.Empty!;
        public string ImageUrl { get; set; } = string.Empty;
        public string PickupLocation { get; set; } = string.Empty!;
        public double PickupLat { get; set; }
        public double PickupLng { get; set; }
        public DateTime PickupDate { get; set; }
        public TimeOnly PickupTime { get; set; }
        public string DropoffLocation { get; set; } = string.Empty!;
        public double DropoffLat { get; set; }
        public double DropoffLng { get; set; }
        public DateTime DropoffDate { get; set; }
        public TimeOnly DropoffTime { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
