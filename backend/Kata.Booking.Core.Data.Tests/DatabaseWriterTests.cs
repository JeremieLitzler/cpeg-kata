using Kata.Booking.Core.Business.Dto;
using Kata.Booking.Core.Data.Tests.Mocks;
using Kata.Booking.Core.Data.Tests.Stubs;
using Newtonsoft.Json;

namespace Kata.Booking.Core.Data.Tests
{
    public class DatabaseWriterTests
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void Add_Should_SerializeAndWriteToPath()
        {
            // Arrange
            var mockFileWriter = new MockFileWriter();
            var databaseFile = "databases\\rooms.json";
            var entity = RoomStubs.OneRoom();
            // Act
            new DatabaseWriter(mockFileWriter, databaseFile).Add<Room>(entity);

            // Assert
            Assert.That(Base.BuildFilePath(databaseFile), Is.EqualTo(mockFileWriter.LastWrittenPath));
            // Assert on serialized content (can be more specific based on object structure)
            Assert.That(mockFileWriter.LastWrittenContent, Contains.Substring(entity.Id));
            Assert.That(mockFileWriter.LastWrittenContent, Contains.Substring(entity.Name));
        }
        [Test]
        public void Remove_Should_SerializeAndWriteToPath()
        {
            // Arrange
            var mockFileWriter = new MockFileWriter();
            var databaseFile = "databases\\rooms.json";
            var entity = RoomStubs.OneRoom();
            // Act
            new DatabaseWriter(mockFileWriter, databaseFile).Add<Room>(entity);
            new DatabaseWriter(mockFileWriter, databaseFile).Remove<Room>(entity.Id);
            // Assert
            // Assert on serialized content (can be more specific based on object structure)
            Assert.That(mockFileWriter.LastWrittenContent, !Contains.Substring(entity.Id));
            Assert.That(mockFileWriter.LastWrittenContent, !Contains.Substring(entity.Name));
        }
    }
}