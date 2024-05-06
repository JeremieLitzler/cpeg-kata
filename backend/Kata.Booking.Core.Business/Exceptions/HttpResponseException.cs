using System.Net;

namespace Kata.Booking.Core.Business
{
    public class HttpResponseException : Exception
    {
        public HttpResponseException(HttpStatusCode enumStatusCode, object? value = null)
        {
            Value = value;

            StatusCode = (int)enumStatusCode;
        }

        public HttpResponseException(int statusCode, object? value = null) =>
            (StatusCode, Value) = (statusCode, value);

        public int StatusCode { get; }

        public object? Value { get; }
    }
}
