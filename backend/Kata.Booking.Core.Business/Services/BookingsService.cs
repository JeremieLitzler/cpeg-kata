using Kata.Booking.Core.Business.Dto;
using Kata.Booking.Core.Business.Extensions;
using Kata.Booking.Core.Business.Interfaces;
using Kata.Booking.Core.Business.Wrappers;
using Kata.Booking.Core.Contracts;
using Kata.Booking.Core.Data;
using System.Net;

namespace Kata.Booking.Core.Business.Services
{
    public class BookingsService : IBookingsService
    {

        private readonly IDatabaseReader _databaseReader;
        //TODO > Implement DI
        //private readonly IDatabaseWriter _databaseWriter;
        public BookingsService(IDatabaseReader databaseReader/*, IDatabaseWriter databaseWriter*/)
        {
            _databaseReader = databaseReader;
            //_databaseWriter = databaseWriter;
        }

        public IEnumerable<Dto.Booking> GetBookings(string? roomId = null)
        {
            var bookings = _databaseReader.ReadDatabase<Dto.Booking>(DatabaseStruct.BookingsDb);
            var rooms = _databaseReader.ReadDatabase<Dto.Room>(DatabaseStruct.RoomsDb);
            bookings.ForEach(booking =>
            {
                var room = rooms.FirstOrDefault(r => r.Id == booking.BookingDetails.RoomId);
                
                booking.BookingDetails.RoomName = room == null ? "Undefined room" : room?.Name;
            });

            if (roomId == null)
            {
                return bookings;
            }

            return bookings.Where(booking => booking.BookingDetails?.Room.Id == roomId);
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
