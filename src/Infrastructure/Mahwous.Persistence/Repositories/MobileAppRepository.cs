using Mahwous.Core.Entities;
using Mahwous.Core.Filters;
using Mahwous.Core.Interfaces.Repositories;

namespace MahwousWeb.Persistent.Repositories
{
    public class MobileAppRepository : EntityRepository<MobileApp, MobileAppFilter>, IMobileAppRepository
    {
        public MobileAppRepository(ApplicationDbContext context) : base(context)
        { }

    }
}
