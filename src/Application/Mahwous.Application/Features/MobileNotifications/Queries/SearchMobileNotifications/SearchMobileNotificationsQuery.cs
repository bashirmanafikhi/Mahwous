using Mahwous.Application.Interfaces;
using Mahwous.Core.Enums;
using Mahwous.Core.Filters;
using Mahwous.Core.Pagination;

namespace Mahwous.Application.Features.MobileNotifications
{
    public class SearchMobileNotificationsQuery : MobileNotificationFilter, ISearchQuery<MobileNotificationFilter, SearchMobileNotificationsResponse>
    {
        public PaginationDetails Pagination { get; set; } = new PaginationDetails();
        public EntitySortType SortType { get; set; } = EntitySortType.Random;
    }
}
