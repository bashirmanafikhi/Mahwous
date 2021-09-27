using Mahwous.Application.Interfaces.Repositories;
using Mahwous.Core.Models;

namespace MahwousWeb.Persistent.Repositories
{
    public class StatusRepository<T> : BaseRepository<T>, IStatusRepository<T> where T: Status
    {
        public StatusRepository(ApplicationDbContext context) : base(context)
        { }
    }
}
