namespace Kata.Booking.Core.Business.Dto
{
    public class BookingRequest
    {
        public Individual? Booker { get; set; }
        public BookingTimeSlot? BookingTimeSlot { get; set; }

        public void Validate()
        {
            if (Booker == null)
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.BadRequest, "No information about the person making the booking");
            }
            if (BookingTimeSlot == null)
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.BadRequest, "No slot picked for this booking");
            }

            Booker.Validate();
        }

    }
}
