using Mahwous.Core.Entities;
using Mahwous.Core.Filters;
using Mahwous.API.Controllers.MyControllerBase;
using Mahwous.API.Helpers;
using MahwousWeb.Persistent;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Threading.Tasks;
using MediatR;
using Mahwous.Application.Features.Posts;

namespace Mahwous.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AAPostsController : ControllerBase
    {
        private readonly IMediator mediator;

        public AAPostsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<int>> CreatePost([FromForm] CreatePostCommand command)
        {
            var result = await mediator.Send(command);
            return result;
        }


        [HttpGet("list")]
        public async Task<ActionResult<ListPostsResponse>> list(ListPostsQuery query)
        {
            var result = await mediator.Send(query);
            return result;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetPostDetailsResponse>> details(int id, GetPostDetailsQuery query)
        {
            query.Id = id;
            var result = await mediator.Send(query);
            return result;
        }

    }
}
