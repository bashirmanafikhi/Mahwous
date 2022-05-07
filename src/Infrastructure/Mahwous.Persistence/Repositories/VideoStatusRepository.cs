using Mahwous.Core.Entities;
using Mahwous.Core.Filters;
using Mahwous.Core.Interfaces.Identity;
using Mahwous.Core.Interfaces.Repositories;

namespace Mahwous.Persistence.Repositories
{
    public class VideoStatusRepository : StatusRepository<VideoStatus, VideoFilter>, IVideoStatusRepository
    {
        public VideoStatusRepository(ApplicationDbContext context, IUserService userService) : base(context, userService)
        { }
    }
}
