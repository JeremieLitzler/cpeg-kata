namespace Kata.Booking.Core.Contracts
{
    public interface IDatabaseWriter
    {
        void WriteDatabase(string path, string content);
    }
}
