using Mahwous.Application.Interfaces;
using Mahwous.Core.Entities;
using Mahwous.Core.Enums;
using Mahwous.Core.Filters;
using Mahwous.Core.Pagination;

namespace Mahwous.Application.Features.Posts
{
    public class SearchPostsQuery : ISearchQuery<Post, PostFilter, SearchPostsResponse>
    {
        public PostFilter Filter { get; set; }
        public PaginationDetails Pagination { get; set; } = new PaginationDetails();
        public EntitySortType SortType { get; set; } = EntitySortType.Random;
    }
}
