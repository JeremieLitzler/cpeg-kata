namespace Kata.Booking.Core.Business.Dto
{
    public class BookingTimeSlot
    {
        public string? RoomId { get; set; }
        public string? Id { get; set; }
        public DateTime? Date{ get; set; }
        public string? StartTime { get; set; }
        public string? EndTime { get; set;}
        public Boolean IsBooked { get; set; }
    }
}
