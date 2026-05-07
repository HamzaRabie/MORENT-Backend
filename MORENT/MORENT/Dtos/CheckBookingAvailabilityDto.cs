namespace MORENT.Dtos
{
    public class CheckBookingAvailabilityDto
    {
        public Guid CarId { get; set; }
        public DateTime pickupDate { get; set; }
        public DateTime dropoffDate { get; set; }
    }
}
