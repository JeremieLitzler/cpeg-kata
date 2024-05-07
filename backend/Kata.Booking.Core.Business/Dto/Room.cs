using Kata.Booking.Core.Contracts;

namespace Kata.Booking.Core.Business.Dto
{
    public class Room : IWithId
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
