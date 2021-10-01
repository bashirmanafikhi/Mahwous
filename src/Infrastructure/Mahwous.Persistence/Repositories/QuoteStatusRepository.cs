using Mahwous.Application.Interfaces.Repositories;
using Mahwous.Core.Entities;

namespace MahwousWeb.Persistent.Repositories
{
    public class QuoteStatusRepository : StatusRepository<QuoteStatus>, IQuoteStatusRepository
    {
        public QuoteStatusRepository(ApplicationDbContext context) : base(context)
        { }
    }
}
