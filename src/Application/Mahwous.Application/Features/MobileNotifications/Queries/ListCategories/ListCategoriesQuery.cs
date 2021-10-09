using Mahwous.Application.Mappings;
using Mahwous.Core.Filters;
using MediatR;

namespace Mahwous.Application.Features.MobileNotifications
{
    public class ListMobileNotificationsQuery : MobileNotificationFilter, IMapTo<MobileNotificationFilter>, IRequest<ListMobileNotificationsResponse>
    {

    }
}
