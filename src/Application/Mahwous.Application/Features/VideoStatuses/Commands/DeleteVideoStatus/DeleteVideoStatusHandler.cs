using Mahwous.Application.Exceptions;
using Mahwous.Core.Interfaces;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.VideoStatuses
{
    public class DeleteVideoStatusHandler : IRequestHandler<DeleteVideoStatusCommand>
    {

        private readonly IVideoStatusRepository videoRepository;
        private readonly IFileStorageService fileService;

        public DeleteVideoStatusHandler(IVideoStatusRepository videoRepository, IFileStorageService fileService)
        {
            this.videoRepository = videoRepository;
            this.fileService = fileService;
        }

        public async Task<Unit> Handle(DeleteVideoStatusCommand request, CancellationToken cancellationToken)
        {
            // get the entity to check existence and to take files urls from it
            var video = await videoRepository.GetByIdAsync(request.Id);
            if (video == null)
                throw new NotFoundException("The video is not exist");

            // Delete Files
            await fileService.DeleteFile(video.CoverPath);

            // Delete data
            await videoRepository.DeleteAsync(video.Id);
            return Unit.Value;
        }
    }
}
