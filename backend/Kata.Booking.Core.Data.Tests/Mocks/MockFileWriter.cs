
using Kata.Booking.Core.Contracts;

namespace Kata.Booking.Core.Data.Tests.Mocks
{
    public class MockFileWriter : IFileWriter
    {
        public string LastWrittenPath { get; private set; }
        public string LastWrittenContent { get; private set; }

        public void WriteAllText(string path, string content)
        {
            LastWrittenPath = path;
            LastWrittenContent = content;
        }
    }
}
