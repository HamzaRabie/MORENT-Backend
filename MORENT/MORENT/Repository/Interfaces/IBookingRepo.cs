using Microsoft.AspNetCore.Mvc;
using MORENT.Dtos;

namespace MORENT.Repository.Interfaces
{
    public interface IBookingRepo
    {
        Task<List<GetTopBookings>> GetTopBookingsAsync();
        Task<List<GetBookingDto>> GetRecent();
    }
}
