using Mahwous.Application.Features.ImageStatuses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Mahwous.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImageStatusesController : ControllerBase
    {
        private readonly IMediator mediator;

        public ImageStatusesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromForm] CreateImageStatusCommand command)
        {
            return await mediator.Send(command);
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult<int>> Update([FromForm] UpdateImageStatusCommand command)
        {
            return await mediator.Send(command);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteImageStatusCommand { Id = id };
            await mediator.Send(command);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetImageStatusDetailsResponse>> Details([FromRoute] int id)
        {
            var query = new GetImageStatusDetailsQuery { Id = id };
            return await mediator.Send(query);
        }

        [HttpGet("random")]
        public async Task<ActionResult<GetRandomImageStatusResponse>> Random()
        {
            var query = new GetRandomImageStatusQuery();
            return await mediator.Send(query);
        }

        [HttpGet()]
        public async Task<ActionResult<SearchImageStatusesResponse>> Search([FromQuery] SearchImageStatusesQuery query)
        {
            return await mediator.Send(query);
        }

        [HttpGet("list")]
        public async Task<ActionResult<ListImageStatusesResponse>> List([FromQuery] ListImageStatusesQuery query)
        {
            return await mediator.Send(query);
        }

        [HttpGet("download/{id}")]
        public async Task<IActionResult> Download([FromRoute] int id)
        {
            var query = new DownloadImageStatusQuery { Id = id };
            var response = await mediator.Send(query);
            return File(response.ImageFile, "application/octet-stream", response.FileName);
        }
    }
}
