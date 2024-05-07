using System.Runtime.CompilerServices;

namespace Kata.Booking.Core.Business.Dto
{
    public class BookingDetails
    {
        public string RoomId { get; set; } = string.Empty;
        public string Id { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string StartTime { get; set; } = string.Empty;
        public string EndTime { get; set; } = string.Empty;
    }
}

