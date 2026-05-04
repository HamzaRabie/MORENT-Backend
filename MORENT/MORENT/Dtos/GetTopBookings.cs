namespace MORENT.Dtos
{
    public class GetTopBookings
    {
        public  string Category { get; set; } = string.Empty!;
        public int Count { get; set; }
    }
}
