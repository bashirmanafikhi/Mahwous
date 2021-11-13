using Mahwous.Application.Mappings;
using Mahwous.Core.Entities;

namespace Mahwous.Application.Features.Categories
{
    public class GetRandomCategoryResponse : GetCategoryDetailsResponse, IMapFrom<Category>
    {

    }
}
