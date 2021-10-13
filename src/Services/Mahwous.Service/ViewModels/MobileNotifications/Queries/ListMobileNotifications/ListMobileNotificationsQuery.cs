using Mahwous.Core.Enums;
using Mahwous.Core.Filters;

namespace Mahwous.Service.ViewModels.MobileNotifications
{
    public class ListMobileNotificationsQuery : MobileNotificationFilter
    {
        public EntitySortType SortType { get; set; } = EntitySortType.Random;
    }
}
