using AutoMapper;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.VideoStatuses
{
    public class GetRandomVideoStatusHandler : IRequestHandler<GetRandomVideoStatusQuery, GetRandomVideoStatusResponse>
    {
        private readonly IVideoStatusRepository videoRepository;
        private readonly IMapper mapper;

        public GetRandomVideoStatusHandler(IVideoStatusRepository videoRepository, IMapper mapper)
        {
            this.videoRepository = videoRepository;
            this.mapper = mapper;
        }

        public async Task<GetRandomVideoStatusResponse> Handle(GetRandomVideoStatusQuery request, CancellationToken cancellationToken)
        {
            var video = await videoRepository.GetRandomAsync();
            var response = mapper.Map<GetRandomVideoStatusResponse>(video);
            return response;
        }
    }
}
