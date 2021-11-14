using Mahwous.Application.Mappings;
using Mahwous.Core.Entities;
using Mahwous.Core.Pagination;

namespace Mahwous.Application.Features.ExternalLinks
{
    public class SearchExternalLinksResponse : PaginatedList<ExternalLink>, IMapFrom<PaginatedList<ExternalLink>>
    {

    }
}
