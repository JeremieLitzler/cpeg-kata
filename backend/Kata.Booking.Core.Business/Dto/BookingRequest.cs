using System.ComponentModel.DataAnnotations;

namespace Kata.Booking.Core.Business.Dto
{
    public class BookingRequest
    {
        public Individual? Booker { get; set; }
        public TimeSlot? TimeSlot { get; set; }
        [Required(ErrorMessage = "Room ID is required")]
        public string? RoomId { get; set; }
        [Required(ErrorMessage = "Date is required")]
        //TODO > could check the date is not in the past
        public DateTime? Date { get; set; }

        public void Validate()
        {
            if (Booker == null)
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.UnprocessableEntity, "No information about the person making the booking");
            }
            if (TimeSlot== null)
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.UnprocessableEntity, "No slot picked for this booking");
            }

            Booker.Validate();
            TimeSlot.Validate();

            // TODO > read the rooms to check the room exists
            var roomExists = true;
            if (!roomExists)
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.UnprocessableEntity, $"Room {RoomId} doesn't exist.");
            }
            // TODO > read the booking and check if there is a booking at the date and slot for the RoomId
            var roomBooked = false;
            if (roomBooked)
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.UnprocessableEntity, "Room already booked");
            }

        }

    }
}
