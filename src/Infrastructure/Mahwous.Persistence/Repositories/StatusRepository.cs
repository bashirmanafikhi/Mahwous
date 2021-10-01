using Mahwous.Core.Interfaces.Repositories;
using Mahwous.Core.Entities;

namespace MahwousWeb.Persistent.Repositories
{
    public class StatusRepository<T> : EntityRepository<T>, IStatusRepository<T> where T : Status
    {
        public StatusRepository(ApplicationDbContext context) : base(context)
        { }
    }
}
