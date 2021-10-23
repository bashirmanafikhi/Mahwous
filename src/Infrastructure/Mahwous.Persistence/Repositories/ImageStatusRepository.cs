using Mahwous.Core.Entities;
using Mahwous.Core.Filters;
using Mahwous.Core.Interfaces.Repositories;

namespace Mahwous.Persistence.Repositories
{
    public class ImageStatusRepository : StatusRepository<ImageStatus, ImageFilter>, IImageStatusRepository
    {
        public ImageStatusRepository(ApplicationDbContext context) : base(context)
        { }
    }
}
