using Mahwous.Application.Interfaces.Repositories;
using Mahwous.Core.Models;

namespace MahwousWeb.Persistent.Repositories
{
    public class MobileAppRepository : BaseRepository<MobileApp>, IMobileAppRepository
    {
        public MobileAppRepository(ApplicationDbContext context) : base(context)
        { }

    }
}
