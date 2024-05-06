namespace Kata.Booking.Core.Business.Extensions
{
    public interface IHaveId
    {
        string Id { get; }
    }
    public static class LinqExtensions
    {
        public static void RemoveAllById<T>(this List<T>? list, string id) where T : IHaveId
        {
            list?.RemoveAll(item => item.Id == id);
        }
    }
}
