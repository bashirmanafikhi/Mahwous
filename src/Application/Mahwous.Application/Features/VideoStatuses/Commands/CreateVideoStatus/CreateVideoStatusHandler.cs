using AutoMapper;
using Mahwous.Application.Extensions;
using Mahwous.Core.Entities;
using Mahwous.Core.Interfaces;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.VideoStatuses
{
    public class CreateVideoStatusHandler : IRequestHandler<CreateVideoStatusCommand, int>
    {

        private readonly IVideoStatusRepository videoRepository;
        private readonly IFileStorageService fileService;
        private readonly IMapper mapper;

        public CreateVideoStatusHandler(IVideoStatusRepository videoRepository, IFileStorageService fileService, IMapper mapper)
        {
            this.videoRepository = videoRepository;
            this.fileService = fileService;
            this.mapper = mapper;
        }


        public async Task<int> Handle(CreateVideoStatusCommand request, CancellationToken cancellationToken)
        {
            // Mapping
            VideoStatus video = mapper.Map<VideoStatus>(request);

            // Save Files
            var coverFile = request.Cover.ToMemoryStream();
            video.CoverPath = await fileService.SaveFile(coverFile, Core.Enums.FileType.Image);

            var videoFile = request.Video.ToMemoryStream();
            video.VideoPath = await fileService.SaveFile(videoFile, Core.Enums.FileType.Video);

            // Save Data
            await videoRepository.AddAsync(video);
            return video.Id;
        }
    }
}
