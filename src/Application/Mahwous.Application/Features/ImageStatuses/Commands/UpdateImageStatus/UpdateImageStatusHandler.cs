using AutoMapper;
using Mahwous.Application.Exceptions;
using Mahwous.Application.Extensions;
using Mahwous.Core.Entities;
using Mahwous.Core.Interfaces;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.ImageStatuses
{
    public class UpdateImageStatusHandler : IRequestHandler<UpdateImageStatusCommand, int>
    {

        private readonly IImageStatusRepository imageRepository;
        private readonly IFileStorageService fileService;
        private readonly IMapper mapper;

        public UpdateImageStatusHandler(IImageStatusRepository imageRepository, IFileStorageService fileService, IMapper mapper)
        {
            this.imageRepository = imageRepository;
            this.fileService = fileService;
            this.mapper = mapper;
        }


        public async Task<int> Handle(UpdateImageStatusCommand request, CancellationToken cancellationToken)
        {
            // get the original object to check existence and to take files urls from it
            var oldImageStatus = await imageRepository.GetByIdAsync(request.Id);
            if (oldImageStatus == null)
                throw new NotFoundException("The image is not exist");

            // Mapping
            ImageStatus newImageStatus = mapper.Map<ImageStatus>(request);

            // Map the old files urls
            newImageStatus.ImagePath = oldImageStatus.ImagePath;

            // Save Files if a new file comes
            if (request.Image != null && request.Image.Length > 0)
            {
                var imageFile = request.Image.ToMemoryStream();
                newImageStatus.ImagePath = await fileService.EditFile(newImageStatus.ImagePath, imageFile, Core.Enums.FileType.Image);
            }

            // Save Data
            await imageRepository.UpdateAsync(newImageStatus);
            return newImageStatus.Id;
        }
    }
}
