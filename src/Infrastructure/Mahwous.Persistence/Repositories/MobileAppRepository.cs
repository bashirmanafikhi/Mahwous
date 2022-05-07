using Mahwous.Core.Entities;
using Mahwous.Core.Filters;
using Mahwous.Core.Interfaces.Identity;
using Mahwous.Core.Interfaces.Repositories;

namespace Mahwous.Persistence.Repositories
{
    public class MobileAppRepository : EntityRepository<MobileApp, MobileAppFilter>, IMobileAppRepository
    {
        public MobileAppRepository(ApplicationDbContext context, IUserService userService) : base(context, userService)
        { }

    }
}
