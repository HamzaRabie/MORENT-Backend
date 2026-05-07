using MORENT.Dtos;

namespace MORENT.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<PaymentResponseDto> CreatePayment(CreatePaymentDto paymentDto);
        Task<PaymentResponseDto> CheckBookingAvailability(CheckBookingAvailabilityDto paymentDto);
    }
}
