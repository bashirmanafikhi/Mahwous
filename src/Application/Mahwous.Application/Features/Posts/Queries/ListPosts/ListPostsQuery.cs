using Mahwous.Application.Mappings;
using Mahwous.Core.Filters;
using MediatR;

namespace Mahwous.Application.Features.Posts
{
    public class ListPostsQuery : PostFilter, IMapTo<PostFilter>, IRequest<ListPostsResponse>
    {

    }
}
