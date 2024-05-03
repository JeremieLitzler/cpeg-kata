using Kata.Booking.Core.Business.Dto;
using Kata.Booking.Core.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Booking.Core.Business.Services
{
    public class RoomsService : IRoomsService
    {
        public IEnumerable<BookingTimeSlot> GetBookingTimeSlots(string roomId, DateTime requestDate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Room> GetRooms()
        {
            throw new NotImplementedException();
        }
    }
}
