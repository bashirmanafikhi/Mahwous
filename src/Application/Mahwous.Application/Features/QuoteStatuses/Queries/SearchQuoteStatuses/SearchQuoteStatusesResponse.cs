using Mahwous.Application.Mappings;
using Mahwous.Core.Entities;
using Mahwous.Core.Pagination;

namespace Mahwous.Application.Features.QuoteStatuses
{
    public class SearchQuoteStatusesResponse : PaginatedList<QuoteStatus>, IMapFrom<PaginatedList<QuoteStatus>>
    {

    }
}
