using MORENT.Dtos;

namespace MORENT.Repository.Interfaces
{
    public interface IPaymentRepo
    {
        Task<PaymentResponseDto>CreatePayment(CreatePaymentDto paymentDto);
        Task<PaymentResponseDto> CheckBookingAvailability(CheckBookingAvailabilityDto paymentDto);

    }
}
