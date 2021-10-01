using Mahwous.Core.Interfaces.Repositories;
using Mahwous.Core.Entities;

namespace MahwousWeb.Persistent.Repositories
{
    public class MobileAppRepository : EntityRepository<MobileApp>, IMobileAppRepository
    {
        public MobileAppRepository(ApplicationDbContext context) : base(context)
        { }

    }
}
