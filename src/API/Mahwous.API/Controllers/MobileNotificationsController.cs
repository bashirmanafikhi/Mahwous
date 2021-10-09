using Mahwous.Application.Features.MobileNotifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Mahwous.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MobileNotificationsController : ControllerBase
    {
        private readonly IMediator mediator;

        public MobileNotificationsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromForm] CreateMobileNotificationCommand command)
        {
            return await mediator.Send(command);
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult<int>> Update([FromForm] UpdateMobileNotificationCommand command)
        {
            return await mediator.Send(command);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteMobileNotificationCommand { Id = id };
            await mediator.Send(command);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetMobileNotificationDetailsResponse>> Details(int id)
        {
            var query = new GetMobileNotificationDetailsQuery { Id = id };
            return await mediator.Send(query);
        }

        [HttpGet("random")]
        public async Task<ActionResult<GetRandomMobileNotificationResponse>> Random()
        {
            var query = new GetRandomMobileNotificationQuery();
            return await mediator.Send(query);
        }

        [HttpGet()]
        public async Task<ActionResult<SearchMobileNotificationsResponse>> Search([FromQuery] SearchMobileNotificationsQuery query)
        {
            return await mediator.Send(query);
        }

        [HttpGet("list")]
        public async Task<ActionResult<ListMobileNotificationsResponse>> List([FromQuery] ListMobileNotificationsQuery query)
        {
            return await mediator.Send(query);
        }
    }
}
