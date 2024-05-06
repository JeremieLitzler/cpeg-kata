namespace Kata.Booking.Core.Data.Tests
{
    public class BaserTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void BuildFilePath_IsCorrect()
        {
            var fileName = "test.json";
            var path = Base.BuildFilePath(fileName);
            Assert.That(path.Contains(fileName));
        }

        [Test]
        public void ValidateFilePath_ThrowsFileNotFound()
        {
            var fileName = "test.json";
            var path = Base.BuildFilePath(fileName);
            Assert.Throws<FileNotFoundException>(() => { Base.ValidatePath(path); });
        }
        [Test]
        public void ValidateFilePath_ThrowsNoException()
        {
            var fileName = "databases\\rooms.json";
            var path = Base.BuildFilePath(fileName);
            path = path.Replace(".Tests", "");
            Assert.DoesNotThrow(() => { Base.ValidatePath(path); });
        }
    }
}