using Mahwous.Core.Enums;
using Mahwous.Core.Filters;

namespace Mahwous.Service.ViewModels.Categories
{
    public class ListCategoriesQuery : CategoryFilter
    {
        public EntitySortType SortType { get; set; } = EntitySortType.Random;
    }
}
