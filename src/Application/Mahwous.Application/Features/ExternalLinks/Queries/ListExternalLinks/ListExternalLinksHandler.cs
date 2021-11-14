using AutoMapper;
using Mahwous.Core.Filters;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.ExternalLinks
{
    public class ListExternalLinksHandler : IRequestHandler<ListExternalLinksQuery, ListExternalLinksResponse>
    {
        private readonly IExternalLinkRepository externalLinkRepository;
        private readonly IMapper mapper;

        public ListExternalLinksHandler(IExternalLinkRepository externalLinkRepository, IMapper mapper)
        {
            this.externalLinkRepository = externalLinkRepository;
            this.mapper = mapper;
        }

        public async Task<ListExternalLinksResponse> Handle(ListExternalLinksQuery request, CancellationToken cancellationToken)
        {
            var filter = mapper.Map<ExternalLinkFilter>(request);
            var externalLinks = await externalLinkRepository.ListAllAsync(filter);
            var response = mapper.Map<ListExternalLinksResponse>(externalLinks);
            return response;
        }
    }
}
