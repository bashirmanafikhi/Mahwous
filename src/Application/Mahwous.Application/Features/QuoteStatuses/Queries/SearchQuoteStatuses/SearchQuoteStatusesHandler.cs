using AutoMapper;
using Mahwous.Core.Filters;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.QuoteStatuses
{
    public class SearchQuoteStatusesHandler : IRequestHandler<SearchQuoteStatusesQuery, SearchQuoteStatusesResponse>
    {
        private readonly IQuoteStatusRepository quoteRepository;
        private readonly IMapper mapper;

        public SearchQuoteStatusesHandler(IQuoteStatusRepository quoteRepository, IMapper mapper)
        {
            this.quoteRepository = quoteRepository;
            this.mapper = mapper;
        }

        public async Task<SearchQuoteStatusesResponse> Handle(SearchQuoteStatusesQuery request, CancellationToken cancellationToken)
        {
            var filter = mapper.Map<QuoteFilter>(request);
            var quotes = await quoteRepository.SearchAsync(filter, request.Pagination, request.SortType);
            var response = mapper.Map<SearchQuoteStatusesResponse>(quotes);
            return response;
        }
    }
}
