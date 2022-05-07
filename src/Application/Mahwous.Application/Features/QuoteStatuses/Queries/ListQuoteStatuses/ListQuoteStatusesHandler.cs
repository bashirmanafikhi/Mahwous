using AutoMapper;
using Mahwous.Core.Filters;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.QuoteStatuses
{
    public class ListQuoteStatusesHandler : IRequestHandler<ListQuoteStatusesQuery, ListQuoteStatusesResponse>
    {
        private readonly IQuoteStatusRepository quoteRepository;
        private readonly IMapper mapper;

        public ListQuoteStatusesHandler(IQuoteStatusRepository quoteRepository, IMapper mapper)
        {
            this.quoteRepository = quoteRepository;
            this.mapper = mapper;
        }

        public async Task<ListQuoteStatusesResponse> Handle(ListQuoteStatusesQuery request, CancellationToken cancellationToken)
        {
            var filter = mapper.Map<QuoteFilter>(request.Filter);
            var quotes = await quoteRepository.ListAllAsync(filter);
            var response = mapper.Map<ListQuoteStatusesResponse>(quotes);
            return response;
        }
    }
}
