namespace Kata.Booking.Core.Business.Extensions
{
    public static class BookingExtensions
    {
        public static bool IsBookingMatchFilters(this Dto.Booking booking, string roomId, DateTime realRequestDate)
        {
            return booking.BookingDetails?.Date.Date == realRequestDate.Date && booking.BookingDetails.RoomId == roomId;
        }
    }
}
