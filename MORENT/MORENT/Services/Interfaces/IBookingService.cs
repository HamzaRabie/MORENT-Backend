using MORENT.Dtos;

namespace MORENT.Services.Interfaces
{
    public interface IBookingService
    {
        Task<List<GetTopBookings>> GetTopBookings();
        Task<List<GetBookingDto>> GetRecent();
    }
}
