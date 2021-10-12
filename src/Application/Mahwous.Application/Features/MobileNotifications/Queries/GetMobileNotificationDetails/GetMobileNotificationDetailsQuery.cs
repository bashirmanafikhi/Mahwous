using MediatR;

namespace Mahwous.Application.Features.MobileNotifications
{
    public class GetMobileNotificationDetailsQuery : IRequest<GetMobileNotificationDetailsResponse>
    {
        public int Id { get; set; }
    }
}
