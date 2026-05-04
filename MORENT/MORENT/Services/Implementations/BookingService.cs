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

        public async Task<List<GetBookingDto>> GetRecent()
        {
            return await bookingRepo.GetRecent();
        }

        public async Task<List<GetTopBookings>> GetTopBookings()
        {
            return await bookingRepo.GetTopBookingsAsync();
        }
    }
}
