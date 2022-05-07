using Mahwous.Application.Interfaces;
using Mahwous.Core.Entities;
using Mahwous.Core.Enums;
using Mahwous.Core.Filters;
using Mahwous.Core.Pagination;

namespace Mahwous.Application.Features.ImageStatuses
{
    public class SearchImageStatusesQuery : ISearchStatusQuery<ImageStatus, ImageFilter, SearchImageStatusesResponse>
    {
        public ImageFilter Filter { get; set; }
        public PaginationDetails Pagination { get; set; } = new PaginationDetails();
        public StatusSortType SortType { get; set; } = StatusSortType.Random;
    }
}
