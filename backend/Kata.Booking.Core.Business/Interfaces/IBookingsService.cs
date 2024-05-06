using Kata.Booking.Core.Business.Dto;

namespace Kata.Booking.Core.Business.Interfaces
{
    public interface IBookingsService
    {
        public IEnumerable<Dto.Booking> GetBookings(string? rooomId = null);
        public string MakeBooking(BookingRequest request);
        public void RemoveBooking(string bookingId);
    }
}
