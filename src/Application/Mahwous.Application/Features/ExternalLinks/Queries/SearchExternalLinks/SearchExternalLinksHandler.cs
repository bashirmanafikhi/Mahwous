using AutoMapper;
using Mahwous.Core.Filters;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.ExternalLinks
{
    public class SearchExternalLinksHandler : IRequestHandler<SearchExternalLinksQuery, SearchExternalLinksResponse>
    {
        private readonly IExternalLinkRepository externalLinkRepository;
        private readonly IMapper mapper;

        public SearchExternalLinksHandler(IExternalLinkRepository externalLinkRepository, IMapper mapper)
        {
            this.externalLinkRepository = externalLinkRepository;
            this.mapper = mapper;
        }

        public async Task<SearchExternalLinksResponse> Handle(SearchExternalLinksQuery request, CancellationToken cancellationToken)
        {
            var filter = mapper.Map<ExternalLinkFilter>(request.Filter);
            var externalLinks = await externalLinkRepository.SearchAsync(filter, request.Pagination, request.SortType);
            var response = mapper.Map<SearchExternalLinksResponse>(externalLinks);
            return response;
        }
    }
}
