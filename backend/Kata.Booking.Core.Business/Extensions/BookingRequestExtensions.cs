using Kata.Booking.Core.Business.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Booking.Core.Business.Extensions
{
    internal static class BookingRequestExtensions
    {
        internal static Dto.Booking ToBooking(this BookingRequest request)
        {
            return new Dto.Booking()
            {
                Id = Guid.NewGuid().ToString(),
                Booker = request.Booker,
                BookingDetails = new BookingDetails()
                {
                    Id = Guid.NewGuid().ToString(),
                    Date = request.Date.Value.Date,
                    StartTime = request.TimeSlot?.StartTime,
                    EndTime = request.TimeSlot?.EndTime,
                    RoomId = request.RoomId
                }
            };
        }
    }
}
