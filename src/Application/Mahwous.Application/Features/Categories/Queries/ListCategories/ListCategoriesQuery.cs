using Mahwous.Application.Features.QuoteStatuses;
using Mahwous.Application.Interfaces;
using Mahwous.Application.Mappings;
using Mahwous.Core.Entities;
using Mahwous.Core.Enums;
using Mahwous.Core.Filters;
using MediatR;

namespace Mahwous.Application.Features.Categories
{
    public class ListCategoriesQuery : IListQuery<Category, CategoryFilter, ListCategoriesResponse>
    {
        public CategoryFilter Filter { get; set; }
        public EntitySortType SortType { get; set; } = EntitySortType.Random;
    }
}
