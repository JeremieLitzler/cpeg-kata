using Kata.Booking.Core.Contracts;

namespace Kata.Booking.Core.Business.Dto
{
    public class Room : IWithId
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
