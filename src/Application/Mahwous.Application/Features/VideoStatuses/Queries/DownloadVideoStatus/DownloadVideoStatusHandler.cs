using AutoMapper;
using Mahwous.Core.Interfaces;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.VideoStatuses
{
    public class DownloadVideoStatusHandler : IRequestHandler<DownloadVideoStatusQuery, DownloadVideoStatusResponse>
    {
        private readonly IVideoStatusRepository videoRepository;
        private readonly IFileStorageService fileService;

        public DownloadVideoStatusHandler(IVideoStatusRepository videoRepository, IFileStorageService fileService)
        {
            this.videoRepository = videoRepository;
            this.fileService = fileService;
        }

        public async Task<DownloadVideoStatusResponse> Handle(DownloadVideoStatusQuery request, CancellationToken cancellationToken)
        {
            var video = await videoRepository.GetByIdAsync(request.Id);

            var response = new DownloadVideoStatusResponse();
            response.FileName = "Mahwous Video " + video.Id + ".mp4";
            response.VideoFile = fileService.GetFile(video.VideoPath);

            return response;
        }
    }
}
