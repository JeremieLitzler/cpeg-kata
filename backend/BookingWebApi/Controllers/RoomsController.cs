using Kata.Booking.Core.Business.Dto;
using Kata.Booking.Core.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookingWebApi.Controllers
{
    [ApiController]
    [Route("api/v1.0/[controller]")]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomsService _roomsService;
        private readonly ILogger<RoomsController> _logger;

        public RoomsController(IRoomsService roomsService, ILogger<RoomsController> logger)
        {
            _roomsService = roomsService;
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<Room> GetRooms()
        {
            return _roomsService.GetRooms();
        }
        [HttpGet]
        [Route("/timeslots/{roomId}/{requestDate}")]
        public IEnumerable<BookingTimeSlot> GetTimeSlots(string roomId, DateTime requestDate)
        {
            return _roomsService.GetBookingTimeSlots(roomId, requestDate);
        }
    }
}