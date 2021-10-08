using Mahwous.Application.Mappings;
using Mahwous.Core.Entities;
using System;

namespace Mahwous.Application.Features.Categories
{
    public class GetCategoryDetailsResponse : Category, IMapFrom<Category>
    {
        public new Type FilterType => null;
    }
}
