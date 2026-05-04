using MORENT.Dtos;
using MORENT.Repository.Interfaces;
using MORENT.Services.Interfaces;

namespace MORENT.Services.Implementations
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepo bookingRepo;

        public BookingService(IBookingRepo bookingRepo)
        {
            this.bookingRepo = bookingRepo;
        }

        public async Task<GetBookingDto?> GetActiveRental()
        {
            return await bookingRepo.GetActiveRental();
        }

        public async Task<List<GetRecentBookingsDto>> GetRecent()
        {
            return await bookingRepo.GetRecent();
        }

        public async Task<List<GetTopBookingsDto>> GetTopBookings()
        {
            return await bookingRepo.GetTopBookingsAsync();
        }
    }
}
