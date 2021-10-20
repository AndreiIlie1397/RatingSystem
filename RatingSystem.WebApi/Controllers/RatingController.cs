using Microsoft.AspNetCore.Mvc;
using RatingSystem.PublishedLanguage.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace RatingSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly MediatR.IMediator _mediator;

        public RatingController(MediatR.IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<string> Rating(AddRatingCommand command, CancellationToken cancellationToken)
        {
            await _mediator.Send(command, cancellationToken);
            return "OK";
        }

        //[HttpGet]
        //[Route("ListOfAccounts")]
      
        //public async Task<List<ListOfAccounts.Model>> GetListOfAccounts([FromQuery] ListOfAccounts.Query query, CancellationToken cancellationToken)
        //{
        //    var result = await _mediator.Send(query, cancellationToken);
        //    return result;
        //}
    }
}
