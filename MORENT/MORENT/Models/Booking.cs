namespace MORENT.Models
{
    public class Booking
    {
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public Car Car { get; set; } = default!;
        public string PickupLocation { get; set; } = string.Empty!;
        public DateTime PickupDate { get; set; }
        public string DropoffLocation { get; set; } = string.Empty!;
        public DateTime DropoffDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; } = string.Empty!;
    }
}
