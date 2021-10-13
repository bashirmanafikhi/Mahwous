using Mahwous.Core.Enums;
using Mahwous.Core.Filters;

namespace Mahwous.Service.ViewModels.Posts
{
    public class ListPostsQuery : PostFilter
    {
        public EntitySortType SortType { get; set; } = EntitySortType.Random;
    }
}
