using Mahwous.Application.Interfaces;
using Mahwous.Core.Enums;
using Mahwous.Core.Filters;
using Mahwous.Core.Pagination;

namespace Mahwous.Application.Features.QuoteStatuses
{
    public class SearchQuoteStatusesQuery : QuoteFilter, ISearchStatusQuery<QuoteFilter, SearchQuoteStatusesResponse>
    {
        public PaginationDetails Pagination { get; set; } = new PaginationDetails();
        public StatusSortType SortType { get; set; } = StatusSortType.Random;
    }
}
