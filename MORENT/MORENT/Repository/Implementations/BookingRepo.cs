using Microsoft.EntityFrameworkCore;
using MORENT.Common.Enums;
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
        public async Task<List<GetTopBookingsDto>> GetTopBookingsAsync()
        {
            var result = await _context.Bookings.GroupBy(b => b.Car.Category)
                .Select(g => new GetTopBookingsDto
                {
                    Category = g.Key,
                    Count = g.Count()
                }).OrderByDescending(x => x.Count).Take(5).ToListAsync();

            return result;
        }

        public async Task<List<GetRecentBookingsDto>> GetRecent()
        {
            var result = await _context.Bookings.Include(b=>b.Car)
                .OrderByDescending(b => b.PickupDate)
                .Take(4)
                .Select(b => new GetRecentBookingsDto
                {
                    CarName = b.Car.Brand,
                    Category = b.Car.Category,
                    ImageUrl = b.Car.ImageUrl,
                    PickupDate = b.PickupDate,
                    TotalPrice = b.TotalPrice

                }).ToListAsync();

            return result;
        }


        public Task<GetBookingDto?> GetActiveRental()
        {
            //to do => auto mapper
            return _context.Bookings
                .Select(b => new GetBookingDto
                {
                    CarName = b.Car.Brand,
                    Status = b.Status,
                    DropoffLocation = b.DropoffLocation,
                    ImageUrl = b.Car.ImageUrl,
                    Category = b.Car.Category,
                    PickupDate = b.PickupDate,
                    PickupLocation = b.PickupLocation,
                    DropoffDate = b.DropoffDate,
                    TotalPrice = b.TotalPrice,
                    DropoffLat = b.DropoffLat,
                    DropoffLng = b.DropoffLng,
                    PickupLat = b.PickupLat,
                    PickupLng = b.PickupLng,
                    DropoffTime = TimeOnly.FromDateTime(b.DropoffDate),
                    PickupTime = TimeOnly.FromDateTime(b.PickupDate)
                }).SingleOrDefaultAsync(b=>b.Status == BookingStatues.Active);
        }
    }

}
