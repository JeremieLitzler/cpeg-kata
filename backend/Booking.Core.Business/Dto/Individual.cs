namespace Kata.Booking.Core.Business.Dto
{
    public class Individual
    {
        public string? Lastname { get; set; }
        public string? Firstname { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Email { get; set; }

        public void Validate()
        {
            if (string.IsNullOrEmpty(Lastname))
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.BadRequest, "No lastname");
            }
            if (string.IsNullOrEmpty(Firstname))
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.BadRequest, "No firstname");
            }
            if (string.IsNullOrEmpty(Email))
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.BadRequest, "No email");
            }
            if (BirthDate == null)
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.BadRequest, "No birthdate");
            }

        }
    }
}
