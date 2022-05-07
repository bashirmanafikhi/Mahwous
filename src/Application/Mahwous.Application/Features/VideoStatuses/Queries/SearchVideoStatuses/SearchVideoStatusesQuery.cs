using Mahwous.Application.Interfaces;
using Mahwous.Core.Entities;
using Mahwous.Core.Enums;
using Mahwous.Core.Filters;
using Mahwous.Core.Pagination;

namespace Mahwous.Application.Features.VideoStatuses
{
    public class SearchVideoStatusesQuery : ISearchStatusQuery<VideoStatus, VideoFilter, SearchVideoStatusesResponse>
    {
        public VideoFilter Filter { get ; set ; }
        public PaginationDetails Pagination { get ; set ; }
        public StatusSortType SortType { get ; set ; }
    }
}
