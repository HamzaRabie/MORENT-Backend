using MORENT.Dtos;
using MORENT.Repository.Interfaces;
using MORENT.Services.Interfaces;

namespace MORENT.Services.Implementations
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepo _paymentRepo;

        public PaymentService(IPaymentRepo paymentRepo)
        {
            _paymentRepo = paymentRepo;
        }

        public async Task<PaymentResponseDto> CheckBookingAvailability(CheckBookingAvailabilityDto paymentDto)
        {
            return await _paymentRepo.CheckBookingAvailability(paymentDto);
        }

        public async Task<PaymentResponseDto> CreatePayment(CreatePaymentDto paymentDto)
        {
            return await _paymentRepo.CreatePayment(paymentDto);
        }
    }
}
