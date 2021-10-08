using Mahwous.Core.Entities;
using Mahwous.Core.Filters;
using Mahwous.Core.Interfaces.Repositories;

namespace MahwousWeb.Persistent.Repositories
{
    public class QuoteStatusRepository : StatusRepository<QuoteStatus, QuoteFilter>, IQuoteStatusRepository
    {
        public QuoteStatusRepository(ApplicationDbContext context) : base(context)
        { }
    }
}
