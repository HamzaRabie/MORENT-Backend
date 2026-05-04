using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MORENT.Services.Interfaces;

namespace MORENT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService bookingService;

        public BookingsController(IBookingService bookingService)
        {
            this.bookingService = bookingService;
        }

        [HttpGet("top")]
        public async Task<IActionResult> GetTopBookingsAsync()
        {
            var result = await bookingService.GetTopBookings();
            if (result == null || !result.Any())
            {
                return NotFound("No bookings found.");
            }
            return Ok(result);
        }

        [HttpGet("recent")]
        public async Task<IActionResult> GetRecentBookingsAsync()
        {
            var result = await bookingService.GetRecent();
            if (result == null || !result.Any())
            {
                return NotFound("No Recent Rents Found");
            }
            return Ok(result);
        }

        [HttpGet("active")]
        public async Task<IActionResult> GetActiveBookingAsync()
        {
            var result = await bookingService.GetActiveRental();
            if (result == null)
            {
                return NotFound("No Active Rents Found");
            }
            return Ok(result);
        }
    }
}
