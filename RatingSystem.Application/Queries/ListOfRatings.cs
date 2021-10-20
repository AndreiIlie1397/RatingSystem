using FluentValidation;
using MediatR;
using RatingSystem.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static RatingSystem.Application.Queries.ListOfRatings.QueryHandler;

namespace RatingSystem.Application.Queries
{
    public class ListOfRatings
    {
        public class Validator : AbstractValidator<Query>
        {
        }


        public class Query : IRequest<List<Model>>
        {
        }

        public class QueryHandler : IRequestHandler<Query, List<Model>>
        {
            private readonly RatingDbContext _dbContext;

            public QueryHandler(RatingDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public Task<List<Model>> Handle(Query request, CancellationToken cancellationToken)
            {

                var db = _dbContext.ConferenceRating;
                var result = db.Select(x => new Model
                {
                    Id = x.Id,
                    ConferenceId = x.ConferenceId,
                    //AvgRating = x.AvgRating
                });

                var x = result.Count();
                return null;
            }


            public class Model
            {
                public int Id { get; set; }
                public int ConferenceId { get; set; }
                public decimal AvgRating { get; set; }
            }
        }
    }
}
