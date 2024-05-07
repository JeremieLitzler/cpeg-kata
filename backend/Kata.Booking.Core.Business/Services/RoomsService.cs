using Kata.Booking.Core.Business.Dto;
using Kata.Booking.Core.Business.Interfaces;
using Kata.Booking.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Booking.Core.Business.Services
{
    public class RoomsService : IRoomsService
    {
        public IEnumerable<TimeSlot> GetAvailability(string roomId, DateTime requestDate)
        {
            var bookings = new DatabaseReader().ReadDatabase<Dto.Booking>(DatabaseStruct.BookingsDb);
            var bookingsForRequestDate = bookings.Where(booking => booking.BookingDetails?.Date.Date == requestDate.Date).ToList();
            var availableSlots = GenerateTimeSlots().Where(slot => !IsSlotBooked(bookingsForRequestDate, slot));

            return availableSlots;
        }

        public bool IsSlotBooked(List<Dto.Booking> bookings, TimeSlot slot)
        {
            var result = bookings.Any(booking => booking.BookingDetails?.StartTime == slot.StartTime && booking.BookingDetails?.EndTime == slot.EndTime);
            return result;
        }

        public IEnumerable<Room> GetRooms()
        {
            return new DatabaseReader().ReadDatabase<Room>(DatabaseStruct.RoomsDb);
        }


        public static List<TimeSlot> GenerateTimeSlots(int interval = 30)
        {
            List<TimeSlot> slots = new List<TimeSlot>();

            // Morning slots (9:00 to 12:00)
            for (var startTime = new TimeSpan(9, 0, 0); startTime < new TimeSpan(12, 0, 0); startTime += TimeSpan.FromMinutes(interval))
            {
                var endTime = startTime + TimeSpan.FromMinutes(interval);
                slots.Add(new TimeSlot
                {
                    StartTime = startTime.ToString("hh\\:mm"),
                    EndTime = endTime.ToString("hh\\:mm")
                });
            }

            // Afternoon slots (14:00 to 16:00)
            for (var startTime = new TimeSpan(14, 0, 0); startTime < new TimeSpan(16, 0, 0); startTime += TimeSpan.FromMinutes(interval))
            {
                var endTime = startTime + TimeSpan.FromMinutes(interval);
                slots.Add(new TimeSlot
                {
                    StartTime = startTime.ToString("hh\\:mm"),
                    EndTime = endTime.ToString("hh\\:mm")
                });
            }

            return slots.Take(10).ToList(); // Limit to a maximum of 10 elements
        }
    }
}
