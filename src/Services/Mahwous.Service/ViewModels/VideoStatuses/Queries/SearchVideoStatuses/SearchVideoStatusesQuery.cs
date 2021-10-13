using Mahwous.Core.Enums;
using Mahwous.Core.Filters;
using Mahwous.Core.Pagination;

namespace Mahwous.Service.ViewModels.VideoStatuses
{
    public class SearchVideoStatusesQuery : VideoFilter
    {
        public PaginationDetails Pagination { get; set; } = new PaginationDetails();
        public StatusSortType SortType { get; set; } = StatusSortType.Random;
    }
}
