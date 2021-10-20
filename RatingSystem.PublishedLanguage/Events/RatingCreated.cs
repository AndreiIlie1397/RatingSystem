using MediatR;
using System;

namespace RatingSystem.PublishedLanguage.Events
{
    public class RatingCreated : INotification
    {
        public int ConferenceId { get; set; }
        public decimal? AvgRating { get; set; }

        public RatingCreated(int conferenceId, decimal? avgRating)
        {
            ConferenceId = conferenceId;
            AvgRating = avgRating;
        }
    }
}
