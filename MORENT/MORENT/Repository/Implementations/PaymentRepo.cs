using Microsoft.EntityFrameworkCore;
using MORENT.Common.Enums;
using MORENT.Context;
using MORENT.Dtos;
using MORENT.Models;
using MORENT.Repository.Interfaces;

namespace MORENT.Repository.Implementations
{
    public class PaymentRepo : IPaymentRepo
    {
        private readonly AppDbContext _context;
        public PaymentRepo(AppDbContext _context)
        {
            this._context = _context;
        }

        public async Task<PaymentResponseDto> CheckBookingAvailability(CheckBookingAvailabilityDto paymentDto)
        {
            var isBooked = await _context.Bookings
                .AnyAsync(b =>
                    b.CarId == paymentDto.CarId &&
                    b.Status == BookingStatues.Active &&
                    b.PickupDate < paymentDto.dropoffDate &&
                    b.DropoffDate > paymentDto.pickupDate
                );

            if (isBooked)
                return new PaymentResponseDto { Message = "Car is not available for the selected dates", Status = "Failed" };

            return new PaymentResponseDto { Message = "Car is available for the selected dates", Status = "Valid" };
        }

        public async Task<PaymentResponseDto> CreatePayment(CreatePaymentDto paymentDto)
        {
            var car = await _context.Cars.FindAsync(paymentDto.CarId);
            if (car == null)
                return new PaymentResponseDto { Message = "Car Not Found", Status = "Failed" };

            var days = (paymentDto.DropoffDate - paymentDto.PickupDate).Days;
            if (days <= 0)
                return new PaymentResponseDto { Message = "Dropoff date must be after pickup date", Status = "Failed" };


            var isBooked = await _context.Bookings
                .AnyAsync(b =>
                    b.CarId == paymentDto.CarId &&
                    b.Status == BookingStatues.Active &&
                    b.PickupDate < paymentDto.DropoffDate &&
                    b.DropoffDate > paymentDto.PickupDate
                );

            if (isBooked)
                return new PaymentResponseDto { Message = "Car is not available for the selected dates" ,Status ="Failed" };

            var totalPrice = car.PricePerDay * days;

            var booking = new Booking
            {
                Id = Guid.NewGuid(),
                CarId = paymentDto.CarId,

                PickupLocation = paymentDto.PickupLocation,
                PickupDate = paymentDto.PickupDate.ToUniversalTime(),

                DropoffLocation = paymentDto.DropoffLocation,
                DropoffDate = paymentDto.DropoffDate.ToUniversalTime(),

                TotalPrice = totalPrice,
                Status = BookingStatues.Reserved,

                DropoffLat = paymentDto.DropoffLat,
                DropoffLng = paymentDto.DropoffLng,
                PickupLat = paymentDto.PickupLat,
                PickupLng = paymentDto.PickupLng,

                Payment = new Payment
                {
                    Id = Guid.NewGuid(),
                    Amount = totalPrice,
                    Method = paymentDto.PaymentMethod,
                    Status = "Paid",
                    PaidAt = DateTime.UtcNow
                }
            };

            _context.Bookings.Add(booking);

            await _context.SaveChangesAsync();

            return new PaymentResponseDto
            {
                Message = "Payment Successful",
                Status = "Success",
                BookingId = booking.Id,
                TotalPrice = totalPrice
            };
        }
    }
}
