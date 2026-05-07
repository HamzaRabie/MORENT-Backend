using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MORENT.Dtos;
using MORENT.Services.Interfaces;

namespace MORENT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePayment([FromBody] CreatePaymentDto paymentDto)
        {
            var result = await _paymentService.CreatePayment(paymentDto);
            if (result.Status == "Failed")
                return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("availability")]
        public async Task<IActionResult> CheckBookingAvailability([FromQuery] CheckBookingAvailabilityDto paymentDto)
        {
            var result = await _paymentService.CheckBookingAvailability(paymentDto);
            if (result.Status == "Failed")
                return BadRequest(result);
            return Ok(result);
        }
    }
}
