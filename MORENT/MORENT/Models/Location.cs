namespace MORENT.Models
{
    public class Location
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string City { get; set; } = string.Empty;
        public double Lat { get; set; }
        public double Lng { get; set; }
    }
}
