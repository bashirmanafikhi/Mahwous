using Mahwous.Core.Enums;
using Mahwous.Core.Filters;
using Mahwous.Core.Pagination;

namespace Mahwous.Service.ViewModels.MobileApps
{
    public class SearchMobileAppsQuery : MobileAppFilter
    {
        public PaginationDetails Pagination { get; set; } = new PaginationDetails();
        public EntitySortType SortType { get; set; } = EntitySortType.Random;
    }
}
