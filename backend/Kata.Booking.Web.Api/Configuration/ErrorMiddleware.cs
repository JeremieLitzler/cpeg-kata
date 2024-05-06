using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net;
using Kata.Booking.Core.Business;
using Kata.Booking.Core.Business.Dto;

namespace Kata.Booking.Web.Api.Configuration
{
    /// <summary>
    /// Parse the HttpResponseException if provided to return HTTP Status Code that it contains.
    /// Otherwise, return a HTTP 500.
    /// </summary>
    public class ErrorMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorMiddleware> _logger;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="next"></param>
        /// <param name="logger"></param>
        public ErrorMiddleware(RequestDelegate next, ILogger<ErrorMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var resultValue = new ErrorMiddlewareDto();
            resultValue.Type = exception.GetType().ToString();

            if (exception is HttpResponseException)
            {
                var httpException = (HttpResponseException)exception;
                context.Response.StatusCode = httpException.StatusCode;
                if (httpException.Value.GetType().IsArray)
                {
                    resultValue.Messages = ((string[])httpException.Value).ToList<string>();
                }
                else
                {
                    resultValue.Messages.Add(httpException.Value.ToString());
                }
                resultValue.IsHandled = true;
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                resultValue.Messages.Add(exception.Message);
            }
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(
                    JsonConvert.SerializeObject(JObject.FromObject(resultValue)));
        }
    }
}
