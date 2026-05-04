using Microsoft.EntityFrameworkCore;
using MORENT.Context;
using MORENT.Dtos;
using MORENT.Repository.Interfaces;

namespace MORENT.Repository.Implementations
{
    public class BookingRepo : IBookingRepo
    {
        private readonly AppDbContext _context;

        public BookingRepo(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<GetTopBookings>> GetTopBookingsAsync()
        {
            var result = await _context.Bookings.GroupBy(b => b.Car.Category)
                .Select(g => new GetTopBookings
                {
                    Category = g.Key,
                    Count = g.Count()
                }).OrderByDescending(x => x.Count).Take(5).ToListAsync();

            return result;
        }

        public async Task<List<GetBookingDto>> GetRecent()
        {
            var result = await _context.Bookings.Include(b=>b.Car)
                .OrderByDescending(b => b.PickupDate)
                .Take(4)
                .Select(b => new GetBookingDto
                {
                    CarName = b.Car.Brand,
                    Category = b.Car.Category,
                    ImageUrl = b.Car.ImageUrl,
                    PickUpDate = b.PickupDate,
                    TotalPrice = b.TotalPrice

                }).ToListAsync();

            return result;
        }
    }

}
