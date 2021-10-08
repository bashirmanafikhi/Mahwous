using Mahwous.Core.Entities;
using Mahwous.Core.Filters;
using Mahwous.Core.Interfaces.Repositories;

namespace MahwousWeb.Persistent.Repositories
{
    public class StatusRepository<T, F> : EntityRepository<T, F>, IStatusRepository<T, F>
        where T : Status
        where F : StatusFilter<T>
    {
        public StatusRepository(ApplicationDbContext context) : base(context)
        { }
    }
}
