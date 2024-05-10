using System.Runtime.CompilerServices;

namespace Kata.Booking.Core.Business.Dto
{
    public class BookingDetails
    {
        public string? RoomId { get; set; } = string.Empty;
        public string? RoomName { get; set; } = string.Empty;
        public Room Room { get; set; }
        public DateTime Date { get; set; }
        public string StartTime { get; set; } = string.Empty;
        public string EndTime { get; set; } = string.Empty;
    }
}

