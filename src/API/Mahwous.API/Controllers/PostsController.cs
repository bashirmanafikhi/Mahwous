using Mahwous.Application.Features.Posts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Mahwous.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly IMediator mediator;

        public PostsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromForm] CreatePostCommand command)
        {
            return await mediator.Send(command);
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult<int>> Update([FromForm] UpdatePostCommand command)
        {
            return await mediator.Send(command);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeletePostCommand { Id = id };
            await mediator.Send(command);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetPostDetailsResponse>> Details(int id)
        {
            var query = new GetPostDetailsQuery { Id = id };
            return await mediator.Send(query);
        }

        [HttpGet("random")]
        public async Task<ActionResult<GetRandomPostResponse>> Random()
        {
            var query = new GetRandomPostQuery();
            return await mediator.Send(query);
        }

        [HttpGet()]
        public async Task<ActionResult<SearchPostsResponse>> Search([FromQuery] SearchPostsQuery query)
        {
            return await mediator.Send(query);
        }

        [HttpGet("list")]
        public async Task<ActionResult<ListPostsResponse>> List([FromQuery] ListPostsQuery query)
        {
            return await mediator.Send(query);
        }
    }
}
