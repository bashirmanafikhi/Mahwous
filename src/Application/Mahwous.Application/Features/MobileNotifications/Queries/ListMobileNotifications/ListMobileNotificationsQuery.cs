using Mahwous.Application.Mappings;
using Mahwous.Core.Enums;
using Mahwous.Core.Filters;
using MediatR;

namespace Mahwous.Application.Features.MobileNotifications
{
    public class ListMobileNotificationsQuery : MobileNotificationFilter, IMapTo<MobileNotificationFilter>, IRequest<ListMobileNotificationsResponse>
    {
        public EntitySortType SortType { get; set; } = EntitySortType.Random;
    }
}
