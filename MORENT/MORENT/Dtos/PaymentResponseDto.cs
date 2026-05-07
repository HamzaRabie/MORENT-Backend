namespace MORENT.Dtos
{
    public class PaymentResponseDto
    {
        public Guid? BookingId { get; set; }
        public  decimal? TotalPrice { get; set; }
        public  string Status { get; set; }
        public  string Message { get; set; }
    }
}
