using Mahwous.Application.Features.ChatRooms;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Mahwous.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatRoomsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ChatRoomsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromForm] CreateChatRoomCommand command)
        {
            return await mediator.Send(command);
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult<int>> Update([FromForm] UpdateChatRoomCommand command)
        {
            return await mediator.Send(command);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteChatRoomCommand { Id = id };
            await mediator.Send(command);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetChatRoomDetailsResponse>> Details(int id)
        {
            var query = new GetChatRoomDetailsQuery { Id = id };
            return await mediator.Send(query);
        }

        [HttpGet("random")]
        public async Task<ActionResult<GetRandomChatRoomResponse>> Random()
        {
            var query = new GetRandomChatRoomQuery();
            return await mediator.Send(query);
        }

        [HttpGet()]
        public async Task<ActionResult<SearchChatRoomsResponse>> Search([FromQuery] SearchChatRoomsQuery query)
        {
            return await mediator.Send(query);
        }

        [HttpGet("list")]
        public async Task<ActionResult<ListChatRoomsResponse>> List([FromQuery] ListChatRoomsQuery query)
        {
            return await mediator.Send(query);
        }
    }
}
