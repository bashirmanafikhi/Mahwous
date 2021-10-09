using Mahwous.Application.Mappings;
using Mahwous.Core.Entities;
using Mahwous.Core.Pagination;

namespace Mahwous.Application.Features.ImageStatuses
{
    public class SearchImageStatusesResponse : PaginatedList<ImageStatus>, IMapFrom<PaginatedList<ImageStatus>>
    {

    }
}
