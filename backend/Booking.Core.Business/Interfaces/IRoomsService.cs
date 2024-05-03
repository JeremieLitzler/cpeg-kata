using Kata.Booking.Core.Business.Dto;

namespace Kata.Booking.Core.Business.Interfaces
{
    public interface IRoomsService
    {
        public IEnumerable<Room> GetRooms();
        public IEnumerable<BookingTimeSlot> GetBookingTimeSlots(string roomId, DateTime requestDate);
    }
}
