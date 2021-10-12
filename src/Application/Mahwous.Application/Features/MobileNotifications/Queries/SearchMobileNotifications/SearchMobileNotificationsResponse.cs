using Mahwous.Application.Mappings;
using Mahwous.Core.Entities;
using Mahwous.Core.Pagination;

namespace Mahwous.Application.Features.MobileNotifications
{
    public class SearchMobileNotificationsResponse : PaginatedList<MobileNotification>, IMapFrom<PaginatedList<MobileNotification>>
    {

    }
}
