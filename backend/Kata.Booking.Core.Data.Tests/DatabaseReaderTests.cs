using Kata.Booking.Core.Business.Dto;
using NuGet.Frameworks;

namespace Kata.Booking.Core.Data.Tests
{
    public class DatabaseReaderTests
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void ReadDatase_Should_ReturnRoomsDbData()
        {
            var fileName = "databases\\rooms.json";
            var list = new DatabaseReader().ReadDatabase<Room>(fileName);
            Assert.That(list.Count(), Is.EqualTo(2));
            foreach (var room in list)
            {
                Assert.That(room.Id, Is.Not.Null);
                Assert.That(room.Name, Is.Not.Null);
            }
        }
        [Test]
        public void ReadDatase_Should_ReturnEmpty()
        {
            var fileName = "databases\\bookings.json";
            var list = new DatabaseReader().ReadDatabase<Kata.Booking.Core.Business.Dto.Booking>(fileName);
            Assert.That(list.Count(), Is.EqualTo(0));
        }
    }
}