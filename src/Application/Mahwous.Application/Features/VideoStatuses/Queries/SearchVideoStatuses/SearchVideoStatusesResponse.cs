using Mahwous.Application.Mappings;
using Mahwous.Core.Entities;
using Mahwous.Core.Pagination;

namespace Mahwous.Application.Features.VideoStatuses
{
    public class SearchVideoStatusesResponse : PaginatedList<VideoStatus>, IMapFrom<PaginatedList<VideoStatus>>
    {

    }
}
