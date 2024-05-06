namespace Kata.Booking.Core.Contracts
{
    public interface IFileReader
    {
        public  List<T> ReadDatabase<T>(string dabatabaseFileName);
    }
}
