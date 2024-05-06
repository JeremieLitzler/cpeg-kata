namespace Kata.Booking.Core.Contracts
{
    public interface IFileWriter
    {
        public void WriteAllText(string path, string content);
    }
}
