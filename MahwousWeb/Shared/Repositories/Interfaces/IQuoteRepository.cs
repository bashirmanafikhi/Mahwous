using MahwousWeb.Shared.Filters;
using MahwousWeb.Shared.Models;
using MahwousWeb.Shared.Pagination;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MahwousWeb.Shared.Repositories.Interfaces
{
    public interface IQuoteRepository : IStatusRepositoryBase
    {
        Task Add(QuoteStatus quote);
        Task<QuoteStatus> Get(int id);
        Task<PaginatedResponse<List<QuoteStatus>>> GetQuotes(PaginationDTO paginationDTO);
        Task Update(QuoteStatus quote);
        Task Delete(int Id);
        Task<PaginatedResponse<List<QuoteStatus>>> GetQuotesFiltered(QuoteFilter quoteFilter);
        Task<FilteredInformations> GetInformations(QuoteFilter filter = null);
        Task<QuoteStatus> GetRandomQuote();
    }
}
