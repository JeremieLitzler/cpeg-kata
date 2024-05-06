namespace Kata.Booking.Core.Business.Dto
{
    public class BookingRequest
    {
        public Individual? Booker { get; set; }
        public AvailableTimeSlot? AvailableTimeSlot { get; set; }

        public void Validate()
        {
            if (Booker == null)
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.UnprocessableEntity, "No information about the person making the booking");
            }
            if (AvailableTimeSlot == null)
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.UnprocessableEntity, "No slot picked for this booking");
            }

            Booker.Validate();
            AvailableTimeSlot.Validate();
        }

    }
}
