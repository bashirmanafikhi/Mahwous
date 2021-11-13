using AutoMapper;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.QuoteStatuses
{
    public class GetQuoteStatusDetailsHandler : IRequestHandler<GetQuoteStatusDetailsQuery, GetQuoteStatusDetailsResponse>
    {
        private readonly IQuoteStatusRepository quoteRepository;
        private readonly IMapper mapper;

        public GetQuoteStatusDetailsHandler(IQuoteStatusRepository quoteRepository, IMapper mapper)
        {
            this.quoteRepository = quoteRepository;
            this.mapper = mapper;
        }

        public async Task<GetQuoteStatusDetailsResponse> Handle(GetQuoteStatusDetailsQuery request, CancellationToken cancellationToken)
        {
            var quote = await quoteRepository.GetByIdAsync(request.Id);
            var response = mapper.Map<GetQuoteStatusDetailsResponse>(quote);
            return response;
        }
    }
}
