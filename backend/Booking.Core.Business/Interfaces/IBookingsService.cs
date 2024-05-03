using Kata.Booking.Core.Business.Dto;

namespace Kata.Booking.Core.Business.Interfaces
{
    public interface IBookingsService
    {
        public IEnumerable<Dto.Booking> GetBookings();
        public void MakeBooking(BookingRequest request);
        public bool RemoveBooking(string bookingId);
    }
}
