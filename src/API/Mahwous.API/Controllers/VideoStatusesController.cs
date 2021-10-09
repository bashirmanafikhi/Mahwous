using Mahwous.Application.Features.VideoStatuses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Mahwous.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VideoStatusesController : ControllerBase
    {
        private readonly IMediator mediator;

        public VideoStatusesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromForm] CreateVideoStatusCommand command)
        {
            return await mediator.Send(command);
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult<int>> Update([FromForm] UpdateVideoStatusCommand command)
        {
            return await mediator.Send(command);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteVideoStatusCommand { Id = id };
            await mediator.Send(command);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetVideoStatusDetailsResponse>> Details(int id)
        {
            var query = new GetVideoStatusDetailsQuery { Id = id };
            return await mediator.Send(query);
        }

        [HttpGet("random")]
        public async Task<ActionResult<GetRandomVideoStatusResponse>> Random()
        {
            var query = new GetRandomVideoStatusQuery();
            return await mediator.Send(query);
        }

        [HttpGet()]
        public async Task<ActionResult<SearchVideoStatusesResponse>> Search([FromQuery] SearchVideoStatusesQuery query)
        {
            return await mediator.Send(query);
        }

        [HttpGet("list")]
        public async Task<ActionResult<ListVideoStatusesResponse>> List([FromQuery] ListVideoStatusesQuery query)
        {
            return await mediator.Send(query);
        }
    }
}
