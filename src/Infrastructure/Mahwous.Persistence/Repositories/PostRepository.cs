using Mahwous.Core.Entities;
using Mahwous.Core.Filters;
using Mahwous.Core.Interfaces.Identity;
using Mahwous.Core.Interfaces.Repositories;

namespace Mahwous.Persistence.Repositories
{
    public class PostRepository : EntityRepository<Post, PostFilter>, IPostRepository
    {
        public PostRepository(ApplicationDbContext context, IUserService userService) : base(context, userService)
        { }

    }
}
