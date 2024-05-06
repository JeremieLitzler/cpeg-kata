using Kata.Booking.Core.Business.Validators;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kata.Booking.Core.Business.Dto
{
    public class AvailableTimeSlot
    {
        [Required(ErrorMessage = "Room ID is required")]
        public string? RoomId { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public DateTime? Date { get; set; }

        [Required(ErrorMessage = "Start Time is required")]
        [TimeValidator]
        public string? StartTime { get; set; }

        [Required(ErrorMessage = "End Time is required")]
        [TimeValidator]
        public string? EndTime { get; set; }

        public Boolean IsBooked { get; set; }

        /// <summary>
        /// Validate the slot to book.
        /// </summary>
        /// <exception cref="HttpResponseException">Returned exception if slot invalid.</exception>
        /// TODO > Use validation rules using annotations
        public void Validate()
        {
            Validators.DtoValidator.Validate(this);

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
