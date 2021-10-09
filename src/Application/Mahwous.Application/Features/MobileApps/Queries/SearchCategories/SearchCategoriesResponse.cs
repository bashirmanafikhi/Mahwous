using Mahwous.Application.Mappings;
using Mahwous.Core.Entities;
using Mahwous.Core.Pagination;

namespace Mahwous.Application.Features.MobileApps
{
    public class SearchMobileAppsResponse : PaginatedList<MobileApp>, IMapFrom<PaginatedList<MobileApp>>
    {

    }
}
