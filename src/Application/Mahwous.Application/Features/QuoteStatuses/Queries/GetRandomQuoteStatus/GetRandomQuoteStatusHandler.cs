using AutoMapper;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.QuoteStatuses
{
    public class GetRandomQuoteStatusHandler : IRequestHandler<GetRandomQuoteStatusQuery, GetRandomQuoteStatusResponse>
    {
        private readonly IQuoteStatusRepository quoteRepository;
        private readonly IMapper mapper;

        public GetRandomQuoteStatusHandler(IQuoteStatusRepository quoteRepository, IMapper mapper)
        {
            this.quoteRepository = quoteRepository;
            this.mapper = mapper;
        }

        public async Task<GetRandomQuoteStatusResponse> Handle(GetRandomQuoteStatusQuery request, CancellationToken cancellationToken)
        {
            var quote = await quoteRepository.GetRandomAsync();
            var response = mapper.Map<GetRandomQuoteStatusResponse>(quote);
            return response;
        }
    }
}
