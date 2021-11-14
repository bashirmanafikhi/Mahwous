using AutoMapper;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.ExternalLinks
{
    public class GetRandomExternalLinkHandler : IRequestHandler<GetRandomExternalLinkQuery, GetRandomExternalLinkResponse>
    {
        private readonly IExternalLinkRepository externalLinkRepository;
        private readonly IMapper mapper;

        public GetRandomExternalLinkHandler(IExternalLinkRepository externalLinkRepository, IMapper mapper)
        {
            this.externalLinkRepository = externalLinkRepository;
            this.mapper = mapper;
        }

        public async Task<GetRandomExternalLinkResponse> Handle(GetRandomExternalLinkQuery request, CancellationToken cancellationToken)
        {
            var externalLink = await externalLinkRepository.GetRandomAsync();
            var response = mapper.Map<GetRandomExternalLinkResponse>(externalLink);
            return response;
        }
    }
}
