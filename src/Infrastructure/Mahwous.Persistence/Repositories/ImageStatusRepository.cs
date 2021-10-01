using Mahwous.Core.Interfaces.Repositories;
using Mahwous.Core.Entities;

namespace MahwousWeb.Persistent.Repositories
{
    public class ImageStatusRepository : StatusRepository<ImageStatus>, IImageStatusRepository
    {
        public ImageStatusRepository(ApplicationDbContext context) : base(context)
        { }
    }
}
