namespace MORENT.Dtos
{
    public record CreatePaymentDto
    {
        public Guid CarId { get; set; }
        public string PickupLocation { get; set; } = string.Empty;
        public double PickupLat { get; set; }
        public double PickupLng { get; set; }
        public DateTime PickupDate { get; set; }
        public string DropoffLocation { get; set; } = string.Empty;
        public double DropoffLat { get; set; }
        public double DropoffLng { get; set; }
        public DateTime DropoffDate { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
    }
}
