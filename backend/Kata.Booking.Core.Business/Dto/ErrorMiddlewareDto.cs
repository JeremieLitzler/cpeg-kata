
namespace Kata.Booking.Core.Business.Dto
{
    [Serializable]
    public class ErrorMiddlewareDto
    {
        public List<string> Messages { get; set; }
        public string Type { get; set; }
        public bool IsHandled { get; set; }

        public ErrorMiddlewareDto() { Messages = new List<string>(); }
    }
}
