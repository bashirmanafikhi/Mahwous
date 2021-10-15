using AutoMapper;
using Mahwous.Application.Exceptions;
using Mahwous.Application.Extensions;
using Mahwous.Core.Entities;
using Mahwous.Core.Interfaces;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.VideoStatuses
{
    public class UpdateVideoStatusHandler : IRequestHandler<UpdateVideoStatusCommand, int>
    {

        private readonly IVideoStatusRepository videoRepository;
        private readonly IFileStorageService fileService;
        private readonly IMapper mapper;

        public UpdateVideoStatusHandler(IVideoStatusRepository videoRepository, IFileStorageService fileService, IMapper mapper)
        {
            this.videoRepository = videoRepository;
            this.fileService = fileService;
            this.mapper = mapper;
        }


        public async Task<int> Handle(UpdateVideoStatusCommand request, CancellationToken cancellationToken)
        {
            // get the original object to check existence and to take files urls from it
            var oldVideoStatus = await videoRepository.GetByIdAsync(request.Id);
            if (oldVideoStatus == null)
                throw new NotFoundException("The video is not exist");

            // Mapping
            VideoStatus newVideoStatus = mapper.Map<VideoStatus>(request);

            // Map the old files urls
            newVideoStatus.CoverPath = oldVideoStatus.CoverPath;

            // Save Files if a new file comes
            if (request.Cover != null && request.Cover.Length > 0)
            {
                var coverFile = request.Cover.ToMemoryStream();
                newVideoStatus.CoverPath = await fileService.EditFile(newVideoStatus.CoverPath, coverFile, Core.Enums.FileType.Image);
            }
            if (request.Video != null && request.Video.Length > 0)
            {
                var videoFile = request.Video.ToMemoryStream();
                newVideoStatus.VideoPath = await fileService.EditFile(newVideoStatus.VideoPath, videoFile, Core.Enums.FileType.Video);
            }

            // Save Data
            await videoRepository.UpdateAsync(newVideoStatus);
            return newVideoStatus.Id;
        }
    }
}
