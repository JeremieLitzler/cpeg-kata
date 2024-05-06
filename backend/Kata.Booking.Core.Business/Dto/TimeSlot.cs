using Kata.Booking.Core.Business.Validators;
using System.ComponentModel.DataAnnotations;

namespace Kata.Booking.Core.Business.Dto
{
    public class TimeSlot
    {
        [Required(ErrorMessage = "Start Time is required")]
        [TimeValidator]
        public string? StartTime { get; set; }

        [Required(ErrorMessage = "End Time is required")]
        [TimeValidator]
        public string? EndTime { get; set; }

        /// <summary>
        /// Validate the slot to book.
        /// </summary>
        /// <exception cref="HttpResponseException">Returned exception if slot invalid.</exception>
        /// TODO > Use validation rules using annotations
        public void Validate()
        {
            Validators.DtoValidator.Validate(this);
        }

    }
}
