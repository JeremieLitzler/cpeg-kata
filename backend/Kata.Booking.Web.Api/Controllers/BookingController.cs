using Kata.Booking.Core.Business.Dto;
using Kata.Booking.Core.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BookingWebApi.Controllers
{
    /// <summary>
    /// Manages the bookings
    /// </summary>
    [ApiController]
    [Route("api/v1.0/[controller]")]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingsService _bookingsService;
        private readonly ILogger<BookingsController> _logger;

        /// <summary>
        /// Instanciate controller with the booking service and logger
        /// </summary>
        /// <param name="bookingsService">booking service</param>
        /// <param name="logger">logger</param>
        public BookingsController(IBookingsService bookingsService, ILogger<BookingsController> logger)
        {
            _bookingsService = bookingsService;
            _logger = logger;
        }

        /// <summary>
        /// Get all the bookings.
        /// </summary>
        /// <returns>List of booking with respective details</returns>
        [SwaggerResponse(500, "Thrown when unhandled exception is raised.")]
        [HttpGet]
        [Route("")]
        public IEnumerable<Booking> GetBookings()
        {
            return _bookingsService.GetBookings();
        }
        /// <summary>
        /// Get all the bookings by room if provided. If not, returns all the bookings for all rooms.
        /// </summary>
        /// <returns>The new booking Id</returns>
        [SwaggerResponse(200, "Return the list")]
        [SwaggerResponse(422, "A personal information is missing or the time slot is missing. See detailed error message.")]
        [SwaggerResponse(500, "Thrown when unhandled exception is raised.")]
        [HttpPost]
        [Route("")]
        public string MakeBooking(BookingRequest request)
        {
            return _bookingsService.MakeBooking(request);
        }
        /// <summary>
        /// Get all the bookings by room if provided. If not, returns all the bookings for all rooms.
        /// </summary>
        /// <returns>List of booking with respective details</returns>
        [SwaggerResponse(204)]
        [SwaggerResponse(500, "Thrown when unhandled exception is raised.")]
        [HttpDelete]
        [Route("{bookingId}")]
        public IResult RemoveBooking(string bookingId)
        {
            _bookingsService.RemoveBooking(bookingId);
            return Results.NoContent();
        }
    }
}