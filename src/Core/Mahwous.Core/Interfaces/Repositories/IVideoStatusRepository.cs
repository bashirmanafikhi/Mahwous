using Mahwous.Core.Entities;
using Mahwous.Core.Filters;

namespace Mahwous.Core.Interfaces.Repositories
{
    public interface IVideoStatusRepository : IStatusRepository<VideoStatus, VideoFilter>
    {

    }
}
