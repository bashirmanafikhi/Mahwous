using Mahwous.Core.Interfaces.Repositories;
using Mahwous.Core.Entities;

namespace MahwousWeb.Persistent.Repositories
{
    public class PostRepository : EntityRepository<Post>, IPostRepository
    {
        public PostRepository(ApplicationDbContext context) : base(context)
        { }

    }
}
