using MediatR;

namespace RatingSystem.PublishedLanguage.Commands
{
    public class AddRatingCommand : IRequest
    {
        //public int Id { get; set; }
        public string AttendeeEmail { get; set; }
        public int ConferenceId { get; set; }
        public string Category { get; set; }
        public decimal Rating { get; set; }
    }
}
