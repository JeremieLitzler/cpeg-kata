using Kata.Booking.Core.Business.Dto;
using Kata.Booking.Core.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Booking.Core.Business.Services
{
    public class RoomsService : IRoomsService
    {
        public IEnumerable<AvailableTimeSlot> GetAvailability(string roomId, DateTime requestDate)
        {
            return new List<AvailableTimeSlot>();
        }

        public IEnumerable<Room> GetRooms()
        {
            return new List<Room>();
        }
    }
}
