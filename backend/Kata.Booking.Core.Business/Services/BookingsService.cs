using Kata.Booking.Core.Business.Dto;
using Kata.Booking.Core.Business.Extensions;
using Kata.Booking.Core.Business.Interfaces;
using Kata.Booking.Core.Business.Wrappers;
using Kata.Booking.Core.Data;
using System.Net;

namespace Kata.Booking.Core.Business.Services
{
    public class BookingsService : IBookingsService
    {
        public IEnumerable<Dto.Booking> GetBookings(string? roomId = null)
        {
            var bookings = new DatabaseReader().ReadDatabase<Dto.Booking>(DatabaseStruct.BookingsDb);

            if (roomId == null)
            {
                return bookings;
            }

            return bookings.Where(booking => booking.BookingTimeSlot?.RoomId == roomId);
        }

        public string MakeBooking(BookingRequest request)
        {
            request.Validate();
            Dto.Booking newBooking = request.ToBooking();
            new DatabaseWriter(new FileWriter(), DatabaseStruct.BookingsDb).Add(newBooking);
            return newBooking.Id;
        }

        public void RemoveBooking(string bookingId)
        {
            new DatabaseWriter(new FileWriter(), DatabaseStruct.BookingsDb).Remove<Dto.Booking>(bookingId);
        }
    }
}
