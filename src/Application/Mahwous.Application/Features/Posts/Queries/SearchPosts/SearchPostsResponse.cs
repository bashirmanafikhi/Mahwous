using Mahwous.Application.Mappings;
using Mahwous.Core.Entities;
using Mahwous.Core.Pagination;

namespace Mahwous.Application.Features.Posts
{
    public class SearchPostsResponse : PaginatedList<Post>, IMapFrom<PaginatedList<Post>>
    {

    }
}
