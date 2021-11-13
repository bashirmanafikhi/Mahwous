using Mahwous.Application.Features.QuoteStatuses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Mahwous.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuoteStatusesController : ControllerBase
    {
        private readonly IMediator mediator;

        public QuoteStatusesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromForm] CreateQuoteStatusCommand command)
        {
            return await mediator.Send(command);
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult<int>> Update([FromForm] UpdateQuoteStatusCommand command)
        {
            return await mediator.Send(command);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteQuoteStatusCommand { Id = id };
            await mediator.Send(command);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetQuoteStatusDetailsResponse>> Details(int id)
        {
            var query = new GetQuoteStatusDetailsQuery { Id = id };
            return await mediator.Send(query);
        }

        [HttpGet("random")]
        public async Task<ActionResult<GetRandomQuoteStatusResponse>> Random()
        {
            var query = new GetRandomQuoteStatusQuery();
            return await mediator.Send(query);
        }

        [HttpGet()]
        public async Task<ActionResult<SearchQuoteStatusesResponse>> Search([FromQuery] SearchQuoteStatusesQuery query)
        {
            return await mediator.Send(query);
        }

        [HttpGet("list")]
        public async Task<ActionResult<ListQuoteStatusesResponse>> List([FromQuery] ListQuoteStatusesQuery query)
        {
            return await mediator.Send(query);
        }
    }
}
