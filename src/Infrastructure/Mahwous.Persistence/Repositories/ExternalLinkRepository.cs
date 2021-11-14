using Mahwous.Core.Entities;
using Mahwous.Core.Filters;
using Mahwous.Core.Interfaces.Repositories;

namespace Mahwous.Persistence.Repositories
{
    public class ExternalLinkRepository : EntityRepository<ExternalLink, ExternalLinkFilter>, IExternalLinkRepository
    {
        public ExternalLinkRepository(ApplicationDbContext context) : base(context)
        { }

    }
}
