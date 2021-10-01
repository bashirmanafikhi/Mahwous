using Mahwous.Application.Interfaces.Repositories;
using Mahwous.Core.Entities;

namespace MahwousWeb.Persistent.Repositories
{
    public class VideoStatusRepository : StatusRepository<VideoStatus>, IVideoStatusRepository
    {
        public VideoStatusRepository(ApplicationDbContext context) : base(context)
        { }
    }
}
