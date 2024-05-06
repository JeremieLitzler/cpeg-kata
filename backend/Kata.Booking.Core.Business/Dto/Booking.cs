using Kata.Booking.Core.Contracts;
using Kata.Booking.Core.Tools.Extensions;

namespace Kata.Booking.Core.Business.Dto
{
    public class Booking : IWithId
    {
        public string? Id { get; set; }
        public Individual? Booker { get; set; }
        public BookingTimeSlot? BookingTimeSlot { get; set; }

    }

}
