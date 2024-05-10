using Kata.Booking.Core.Business.Interfaces;
using Kata.Booking.Core.Business.Services;
using Kata.Booking.Core.Business.Wrappers;
using Kata.Booking.Core.Contracts;
using Kata.Booking.Core.Data;
using System.IO.Pipelines;

namespace Kata.Booking.Web.Api.Configuration
{
    /// <summary>
    /// Helper class to manage registration of services, singletons, etc using Dependency Inversion.
    /// </summary>
    public static class IocHelper
    {
        /// <summary>
        /// Register the services of the application
        /// </summary>
        /// <param name="services">The services</param>
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IRoomsService, RoomsService>();
            services.AddScoped<IBookingsService, BookingsService>();
            //services.AddScoped<IFileWriter, FileWriter>();
            services.AddScoped<IDatabaseReader, DatabaseReader>();
            //TODO > Add DI for DatabaseWriter
        }
    }
}