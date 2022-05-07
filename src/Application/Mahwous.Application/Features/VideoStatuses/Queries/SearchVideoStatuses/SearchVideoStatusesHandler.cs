using AutoMapper;
using Mahwous.Core.Filters;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.VideoStatuses
{
    public class SearchVideoStatusesHandler : IRequestHandler<SearchVideoStatusesQuery, SearchVideoStatusesResponse>
    {
        private readonly IVideoStatusRepository videoRepository;
        private readonly IMapper mapper;

        public SearchVideoStatusesHandler(IVideoStatusRepository videoRepository, IMapper mapper)
        {
            this.videoRepository = videoRepository;
            this.mapper = mapper;
        }

        public async Task<SearchVideoStatusesResponse> Handle(SearchVideoStatusesQuery request, CancellationToken cancellationToken)
        {
            var filter = mapper.Map<VideoFilter>(request.Filter);
            var videos = await videoRepository.SearchAsync(filter, request.Pagination, request.SortType);
            var response = mapper.Map<SearchVideoStatusesResponse>(videos);
            return response;
        }
    }
}
