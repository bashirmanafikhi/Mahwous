using AutoMapper;
using Mahwous.Core.Interfaces;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.ImageStatuses
{
    public class DownloadImageStatusHandler : IRequestHandler<DownloadImageStatusQuery, DownloadImageStatusResponse>
    {
        private readonly IImageStatusRepository imageRepository;
        private readonly IFileStorageService fileService;

        public DownloadImageStatusHandler(IImageStatusRepository imageRepository, IFileStorageService fileService)
        {
            this.imageRepository = imageRepository;
            this.fileService = fileService;
        }

        public async Task<DownloadImageStatusResponse> Handle(DownloadImageStatusQuery request, CancellationToken cancellationToken)
        {
            var image = await imageRepository.GetByIdAsync(request.Id);

            var response = new DownloadImageStatusResponse();
            response.FileName = "Mahwous Image " + image.Id + ".jpg";
            response.ImageFile = fileService.GetFile(image.ImagePath);

            return response;
        }
    }
}
