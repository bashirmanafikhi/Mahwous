using Mahwous.Application.Interfaces;
using Mahwous.Application.Mappings;
using Mahwous.Core.Entities;
using Mahwous.Core.Enums;
using Mahwous.Core.Filters;
using MediatR;

namespace Mahwous.Application.Features.Posts
{
    public class ListPostsQuery : IListQuery<Post, PostFilter, ListPostsResponse>
    {
        public PostFilter Filter { get; set; }
        public EntitySortType SortType { get; set; } = EntitySortType.Random;
    }
}
