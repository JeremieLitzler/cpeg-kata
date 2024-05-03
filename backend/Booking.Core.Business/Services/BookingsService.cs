using Kata.Booking.Core.Business.Dto;
using Kata.Booking.Core.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Booking.Core.Business.Services
{
    internal class BookingsService : IBookingsService
    {
        public IEnumerable<Dto.Booking> GetBookings()
        {
            throw new NotImplementedException();
        }

        public void MakeBooking(BookingRequest request)
        {
            throw new NotImplementedException();
        }

        public bool RemoveBooking(string bookingId)
        {
            throw new NotImplementedException();
        }
    }
}
