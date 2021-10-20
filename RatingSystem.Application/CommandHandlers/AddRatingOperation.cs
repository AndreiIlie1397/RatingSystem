using MediatR;
using RatingSystem.Data;
using RatingSystem.Models;
using RatingSystem.PublishedLanguage.Commands;
using RatingSystem.PublishedLanguage.Events;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RatingSystem.Application.WriteOperations
{
    public class AddRatingOperation : IRequestHandler<AddRatingCommand>
    {
        private readonly RatingDbContext _dbContext;
        private readonly IMediator _mediator;

        public AddRatingOperation(IMediator mediator, RatingDbContext dbContext)
        {
            _mediator = mediator;
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(AddRatingCommand request, CancellationToken cancellationToken)
        {
            var conferenceXAttendee = new ConferenceXAttendeeRating
            {
                AttendeeEmail = request.AttendeeEmail,
                ConferenceId = request.ConferenceId,
                Category = request.Category,
                Rating = request.Rating
            };
            _dbContext.ConferenceXAttendees.Add(conferenceXAttendee);
            _dbContext.SaveChanges();

            var confId = _dbContext.ConferenceRating.FirstOrDefault(x => x.ConferenceId == request.ConferenceId);
            if (confId == null)
            {
                var conferenceRating = new ConferenceRating
                {
                    ConferenceId = request.ConferenceId,
                    AvgRating = request.Rating
                };

                RatingCreated ratingCreated = new(conferenceRating.ConferenceId, conferenceRating.AvgRating);

                _dbContext.ConferenceRating.Add(conferenceRating);
                _dbContext.SaveChanges();

            }
            else
            {
                var avg = _dbContext.ConferenceXAttendees.Where(x => x.ConferenceId == request.ConferenceId).Average(x => x.Rating);
                confId.AvgRating = avg;

                _dbContext.SaveChanges();
            }

            _dbContext.SaveChanges();

            return Unit.Value;
        }
    }
}
