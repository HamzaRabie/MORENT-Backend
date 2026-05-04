using MORENT.Dtos;

namespace MORENT.Services.Interfaces
{
    public interface IBookingService
    {
        Task<List<GetTopBookingsDto>> GetTopBookings();
        Task<List<GetRecentBookingsDto>> GetRecent();
        Task<GetBookingDto?> GetActiveRental();
    }
}
