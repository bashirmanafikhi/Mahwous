using AutoMapper;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.ExternalLinks
{
    public class GetExternalLinkDetailsHandler : IRequestHandler<GetExternalLinkDetailsQuery, GetExternalLinkDetailsResponse>
    {
        private readonly IExternalLinkRepository externalLinkRepository;
        private readonly IMapper mapper;

        public GetExternalLinkDetailsHandler(IExternalLinkRepository externalLinkRepository, IMapper mapper)
        {
            this.externalLinkRepository = externalLinkRepository;
            this.mapper = mapper;
        }

        public async Task<GetExternalLinkDetailsResponse> Handle(GetExternalLinkDetailsQuery request, CancellationToken cancellationToken)
        {
            var externalLink = await externalLinkRepository.GetByIdAsync(request.Id);
            var response = mapper.Map<GetExternalLinkDetailsResponse>(externalLink);
            return response;
        }
    }
}
