using Mahwous.Application.Mappings;
using Mahwous.Core.Enums;
using Mahwous.Core.Filters;
using MediatR;

namespace Mahwous.Application.Features.Posts
{
    public class ListPostsQuery : PostFilter, IMapTo<PostFilter>, IRequest<ListPostsResponse>
    {
        public EntitySortType SortType { get; set; } = EntitySortType.Random;
    }
}
