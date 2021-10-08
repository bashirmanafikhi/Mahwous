using Mahwous.Core.Entities;
using Mahwous.Core.Filters;
using Mahwous.Core.Interfaces.Repositories;

namespace MahwousWeb.Persistent.Repositories
{
    public class PostRepository : EntityRepository<Post, PostFilter>, IPostRepository
    {
        public PostRepository(ApplicationDbContext context) : base(context)
        { }

    }
}
