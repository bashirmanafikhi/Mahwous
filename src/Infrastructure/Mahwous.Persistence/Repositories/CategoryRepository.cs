using Mahwous.Core.Entities;
using Mahwous.Core.Filters;
using Mahwous.Core.Interfaces.Repositories;

namespace MahwousWeb.Persistent.Repositories
{
    public class CategoryRepository : EntityRepository<Category, CategoryFilter>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        { }

    }
}
