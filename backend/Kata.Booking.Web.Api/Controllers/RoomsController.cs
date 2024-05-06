using Kata.Booking.Core.Business.Dto;
using Kata.Booking.Core.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BookingWebApi.Controllers
{
    /// <summary>
    /// Manages the Rooms
    /// </summary>
    [ApiController]
    [Route("api/v1.0/[controller]")]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomsService _roomsService;
        private readonly IBookingsService _bookingsService;
        private readonly ILogger<RoomsController> _logger;

        /// <summary>
        /// Instanciate controller with the rooms and bookings service and logger
        /// </summary>
        /// <param name="roomsService">rooms service</param>
        /// <param name="bookingsService">bookings service</param>
        /// <param name="logger">logger</param>
        public RoomsController(IRoomsService roomsService, IBookingsService bookingsService, ILogger<RoomsController> logger)
        {
            _roomsService = roomsService;
            _bookingsService = bookingsService;
            _logger = logger;
        }

        /// <summary>
        /// Get all the rooms
        /// </summary>
        /// <returns>List of rooms</returns>
        [SwaggerResponse(500, "Thrown when unhandled exception is raised.")]
        [HttpGet]
        [Route("")]
        public IEnumerable<Room> GetBookingsByRoom()
        {
            return _roomsService.GetRooms();
        }
        /// <summary>
        /// For the booking date, return the available booking slots.
        /// </summary>
        /// <param name="roomId">The room id</param>
        /// <param name="requestDate">The requested date for the booking</param>
        /// <returns>The slots available for the room and requested date</returns>
        [SwaggerResponse(500, "Thrown when unhandled exception is raised.")]
        [HttpGet]
        [Route("{roomId}/availability/date={requestDate}")]
        public IEnumerable<AvailableTimeSlot> GetTimeSlots(string roomId, DateTime requestDate)
        {
            return _roomsService.GetAvailability(roomId, requestDate);
        }


        /// <summary>
        /// Get all the bookings by room if provided. If not, returns all the bookings for all rooms.
        /// </summary>
        /// <returns>List of booking with respective details for the room</returns>
        [SwaggerResponse(500, "Thrown when unhandled exception is raised.")]
        [HttpGet]
        [Route("{roomId}/bookings")]
        public IEnumerable<Booking> GetBookings(string? roomId)
        {
            return _bookingsService.GetBookings(roomId);
        }
    }
}