using Kata.Booking.Core.Business.Dto;
using Kata.Booking.Core.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookingWebApi.Controllers
{
    [ApiController]
    [Route("api/v1.0/[controller]")]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingsService _bookingsService;
        private readonly ILogger<RoomsController> _logger;

        public BookingsController(IBookingsService bookingsService, ILogger<BookingsController> logger)
        {
            _bookingsService = bookingsService;
            _logger = logger;
        }

        [HttpGet(Name = "GetRooms")]
        public IEnumerable<Room> Get()
        {
            return new List<Room>();
        }
    }
}