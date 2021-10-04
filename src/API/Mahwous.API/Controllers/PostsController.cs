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
        public async Task<ActionResult<int>> CreatePost([FromForm] CreatePostCommand command)
        {
            return await mediator.Send(command);
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult<int>> UpdatePost([FromForm] UpdatePostCommand command)
        {
            return await mediator.Send(command);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePost(int id)
        {
            var command = new DeletePostCommand { Id = id };
            await mediator.Send(command);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetPostDetailsResponse>> details(int id)
        {
            var query = new GetPostDetailsQuery { Id = id };
            return await mediator.Send(query);
        }

        [HttpGet("test")]
        public async Task<ActionResult<ListPostsResponse>> list([FromQuery]ListPostsQuery query)
        {
            var result = await mediator.Send(query);
            return result;
        }
    }
}
