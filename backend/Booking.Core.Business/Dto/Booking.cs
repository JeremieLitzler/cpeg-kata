namespace Kata.Booking.Core.Business.Dto
{
    public class Booking
    {
        public string? Id { get; set; }
        public Individual? Booker { get; set; }
        public BookingTimeSlot? BookingTimeSlot { get; set; }

    }

}
