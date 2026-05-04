namespace MORENT.Dtos
{
    public record GetTopBookingsDto
    {
        public  string Category { get; set; } = string.Empty!;
        public int Count { get; set; }
    }
}
