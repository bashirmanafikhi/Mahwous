using Mahwous.Core.Entities;
using Mahwous.Core.Filters;
using Mahwous.Core.Interfaces.Identity;
using Mahwous.Core.Interfaces.Repositories;

namespace Mahwous.Persistence.Repositories
{
    public class CategoryRepository : EntityRepository<Category, CategoryFilter>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context, IUserService userService) : base(context, userService)
        { }

    }
}
