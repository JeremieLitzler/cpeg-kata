namespace Kata.Booking.Core.Contracts
{
    public interface IDatabaseWriter
    {
        void Add<T>(T entity);
        void Remove<T>(string id) where T : IWithId;
    }
}
