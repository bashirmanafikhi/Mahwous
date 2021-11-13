using Mahwous.Application.Mappings;
using Mahwous.Core.Entities;
using Mahwous.Core.Pagination;

namespace Mahwous.Application.Features.Categories
{
    public class SearchCategoriesResponse : PaginatedList<Category>, IMapFrom<PaginatedList<Category>>
    {

    }
}
