using Microsoft.AspNetCore.Mvc;
using MORENT.Dtos;

namespace MORENT.Repository.Interfaces
{
    public interface IBookingRepo
    {
        Task<List<GetTopBookingsDto>> GetTopBookingsAsync();
        Task<List<GetRecentBookingsDto>> GetRecent();
        Task<GetBookingDto?> GetActiveRental();
    }
}
