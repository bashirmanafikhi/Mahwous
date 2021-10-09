using MediatR;

namespace Mahwous.Application.Features.MobileNotifications
{
    public class DeleteMobileNotificationCommand : IRequest
    {
        public int Id { get; set; }
    }
}
