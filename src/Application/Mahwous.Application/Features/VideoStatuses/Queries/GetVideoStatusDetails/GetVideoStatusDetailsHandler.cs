using AutoMapper;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.VideoStatuses
{
    public class GetVideoStatusDetailsHandler : IRequestHandler<GetVideoStatusDetailsQuery, GetVideoStatusDetailsResponse>
    {
        private readonly IVideoStatusRepository videoRepository;
        private readonly IMapper mapper;

        public GetVideoStatusDetailsHandler(IVideoStatusRepository videoRepository, IMapper mapper)
        {
            this.videoRepository = videoRepository;
            this.mapper = mapper;
        }

        public async Task<GetVideoStatusDetailsResponse> Handle(GetVideoStatusDetailsQuery request, CancellationToken cancellationToken)
        {
            var video = await videoRepository.GetByIdAsync(request.Id);
            var response = mapper.Map<GetVideoStatusDetailsResponse>(video);
            return response;
        }
    }
}
