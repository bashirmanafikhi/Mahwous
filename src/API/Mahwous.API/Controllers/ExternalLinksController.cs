using Mahwous.Application.Features.ExternalLinks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Mahwous.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExternalLinksController : ControllerBase
    {
        private readonly IMediator mediator;

        public ExternalLinksController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromForm] CreateExternalLinkCommand command)
        {
            return await mediator.Send(command);
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult<int>> Update([FromForm] UpdateExternalLinkCommand command)
        {
            return await mediator.Send(command);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteExternalLinkCommand { Id = id };
            await mediator.Send(command);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetExternalLinkDetailsResponse>> Details(int id)
        {
            var query = new GetExternalLinkDetailsQuery { Id = id };
            return await mediator.Send(query);
        }

        [HttpGet("random")]
        public async Task<ActionResult<GetRandomExternalLinkResponse>> Random()
        {
            var query = new GetRandomExternalLinkQuery();
            return await mediator.Send(query);
        }

        [HttpGet()]
        public async Task<ActionResult<SearchExternalLinksResponse>> Search([FromQuery] SearchExternalLinksQuery query)
        {
            return await mediator.Send(query);
        }

        [HttpGet("list")]
        public async Task<ActionResult<ListExternalLinksResponse>> List([FromQuery] ListExternalLinksQuery query)
        {
            return await mediator.Send(query);
        }
    }
}
