using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace Kata.Booking.Core.Business.Dto
{
    public class Individual
    {
        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(50, ErrorMessage = "Last Name cannot exceed 50 characters")]
        public string? Lastname { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(50, ErrorMessage = "First Name cannot exceed 50 characters")]
        public string? Firstname { get; set; }

        [Required(ErrorMessage = "Birth Date is required")]
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// <see cref="ValidateEmailFormat"/>
        /// </summary>
        [Required(ErrorMessage = "Email is required")]
        //[EmailAddress("Email format invalid")]
        
        public string? Email { get; set; }

        public void Validate()
        {
            Validators.DtoValidator.Validate(this);
            ValidateEmailFormat();
        }

        public void ValidateEmailFormat()
        {
            try
            {//Better validation compared to [Emailler]
                MailAddress email = new MailAddress(Email);
            }
            catch (FormatException)
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.UnprocessableEntity, "Email is not properly formatted");
            }
        }
    }
}
