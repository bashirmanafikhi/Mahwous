using Mahwous.Application.Interfaces;
using Mahwous.Core.Enums;
using Mahwous.Core.Filters;
using Mahwous.Core.Pagination;

namespace Mahwous.Application.Features.VideoStatuses
{
    public class SearchVideoStatusesQuery : VideoFilter, ISearchStatusQuery<VideoFilter, SearchVideoStatusesResponse>
    {
        public PaginationDetails Pagination { get; set; } = new PaginationDetails();
        public StatusSortType SortType { get; set; } = StatusSortType.Random;
    }
}
