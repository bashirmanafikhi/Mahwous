using Mahwous.Application.Interfaces;
using Mahwous.Application.Mappings;
using Mahwous.Core.Entities;
using Mahwous.Core.Enums;
using Mahwous.Core.Filters;
using MediatR;

namespace Mahwous.Application.Features.MobileNotifications
{
    public class ListMobileNotificationsQuery : IListQuery<MobileNotification, MobileNotificationFilter, ListMobileNotificationsResponse>
    {
        public MobileNotificationFilter Filter { get; set; }
        public EntitySortType SortType { get; set; } = EntitySortType.Random;
    }
}
