using Mahwous.Application.Mappings;
using Mahwous.Core.Entities;

namespace Mahwous.Application.Features.Posts
{
    public class GetRandomPostResponse : GetPostDetailsResponse, IMapFrom<Post>
    {

    }
}
