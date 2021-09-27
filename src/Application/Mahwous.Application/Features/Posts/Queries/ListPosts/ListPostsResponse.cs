using Mahwous.Application.Mappings;
using Mahwous.Core.Models;
using System.Collections.Generic;

namespace Mahwous.Application.Features.Posts
{
    public class ListPostsResponse : List<Post>, IMapFrom<List<Post>>
    {
    }
}
