using Mahwous.Application.Interfaces.Repositories;
using Mahwous.Core.Models;

namespace MahwousWeb.Persistent.Repositories
{
    public class VideoStatusRepository : StatusRepository<VideoStatus>, IVideoStatusRepository
    {
        public VideoStatusRepository(ApplicationDbContext context) : base(context)
        { }
    }
}
