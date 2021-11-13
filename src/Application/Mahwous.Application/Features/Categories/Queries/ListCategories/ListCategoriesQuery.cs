using Mahwous.Application.Mappings;
using Mahwous.Core.Enums;
using Mahwous.Core.Filters;
using MediatR;

namespace Mahwous.Application.Features.Categories
{
    public class ListCategoriesQuery : CategoryFilter, IMapTo<CategoryFilter>, IRequest<ListCategoriesResponse>
    {
        public EntitySortType SortType { get; set; } = EntitySortType.Random;
    }
}
