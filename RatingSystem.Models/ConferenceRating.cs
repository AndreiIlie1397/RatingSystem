using System;
using System.Collections.Generic;

#nullable disable

namespace RatingSystem.Models
{
    public partial class ConferenceRating
    {
        public int Id { get; set; }
        public int ConferenceId { get; set; }
        public decimal? AvgRating { get; set; }
    }
}
