using AutoMapper;
using Mahwous.Core.Filters;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.VideoStatuses
{
    public class ListVideoStatusesHandler : IRequestHandler<ListVideoStatusesQuery, ListVideoStatusesResponse>
    {
        private readonly IVideoStatusRepository videoRepository;
        private readonly IMapper mapper;

        public ListVideoStatusesHandler(IVideoStatusRepository videoRepository, IMapper mapper)
        {
            this.videoRepository = videoRepository;
            this.mapper = mapper;
        }

        public async Task<ListVideoStatusesResponse> Handle(ListVideoStatusesQuery request, CancellationToken cancellationToken)
        {
            var filter = mapper.Map<VideoFilter>(request);
            var videos = await videoRepository.ListAllAsync(filter);
            var response = mapper.Map<ListVideoStatusesResponse>(videos);
            return response;
        }
    }
}
