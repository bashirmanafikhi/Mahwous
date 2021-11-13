using Mahwous.Core.Entities;
using Mahwous.Core.Filters;

namespace Mahwous.Core.Interfaces.Repositories
{
    public interface ICategoryRepository : IEntityRepository<Category, CategoryFilter>
    {

    }
}
