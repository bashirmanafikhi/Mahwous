using Mahwous.Application.Mappings;
using Mahwous.Core.Entities;
using System;

namespace Mahwous.Application.Features.Posts
{
    public class GetPostDetailsResponse : Post, IMapFrom<Post>
    {
        public new Type FilterType => null;
    }
}
