using MediatR;

namespace RatingSystem.PublishedLanguage.Events
{
   public  class RatingUpdated
    {
        public class RatingCreated : INotification
        {
            public decimal? AvgRating { get; set; }

            public RatingCreated(decimal? avgRating)
            {
                AvgRating = avgRating;
            }
        }
    }
}
