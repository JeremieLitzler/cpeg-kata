using Kata.Booking.Core.Contracts;

namespace Kata.Booking.Core.Tools.Extensions
{
    public static class LinqExtensions
    {
        public static void RemoveAllById<T>(this List<T>? list, string id) where T : IWithId
        {
            list?.RemoveAll(item => item.Id == id);
        }
    }
}
