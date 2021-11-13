using AutoMapper;
using Mahwous.Application.Extensions;
using Mahwous.Core.Entities;
using Mahwous.Core.Interfaces;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.ImageStatuses
{
    public class CreateImageStatusHandler : IRequestHandler<CreateImageStatusCommand, int>
    {

        private readonly IImageStatusRepository imageRepository;
        private readonly IFileStorageService fileService;
        private readonly IMapper mapper;

        public CreateImageStatusHandler(IImageStatusRepository imageRepository, IFileStorageService fileService, IMapper mapper)
        {
            this.imageRepository = imageRepository;
            this.fileService = fileService;
            this.mapper = mapper;
        }


        public async Task<int> Handle(CreateImageStatusCommand request, CancellationToken cancellationToken)
        {
            // Mapping
            ImageStatus image = mapper.Map<ImageStatus>(request);

            // Save Files
            var coverFile = request.Image.ToMemoryStream();
            image.ImagePath = await fileService.SaveFile(coverFile, Core.Enums.FileType.Image);

            // Save Data
            await imageRepository.AddAsync(image);
            return image.Id;
        }
    }
}
