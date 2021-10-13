using Mahwous.Core.Enums;
using Mahwous.Core.Filters;
using Mahwous.Core.Pagination;

namespace Mahwous.Service.ViewModels.MobileNotifications
{
    public class SearchMobileNotificationsQuery : MobileNotificationFilter
    {
        public PaginationDetails Pagination { get; set; } = new PaginationDetails();
        public EntitySortType SortType { get; set; } = EntitySortType.Random;
    }
}
