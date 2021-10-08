using Mahwous.Core.Entities;
using Mahwous.Core.Filters;
using Mahwous.Core.Interfaces.Repositories;

namespace MahwousWeb.Persistent.Repositories
{
    public class VideoStatusRepository : StatusRepository<VideoStatus, VideoFilter>, IVideoStatusRepository
    {
        public VideoStatusRepository(ApplicationDbContext context) : base(context)
        { }
    }
}
