using Mahwous.Application.Interfaces;
using Mahwous.Core.Enums;
using Mahwous.Core.Filters;
using Mahwous.Core.Pagination;

namespace Mahwous.Application.Features.ExternalLinks
{
    public class SearchExternalLinksQuery : ExternalLinkFilter, ISearchQuery<ExternalLinkFilter, SearchExternalLinksResponse>
    {
        public PaginationDetails Pagination { get; set; } = new PaginationDetails();
        public EntitySortType SortType { get; set; } = EntitySortType.Random;
    }
}
