using Mahwous.Application.Exceptions;
using Mahwous.Core.Interfaces;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.ImageStatuses
{
    public class DeleteImageStatusHandler : IRequestHandler<DeleteImageStatusCommand>
    {

        private readonly IImageStatusRepository imageRepository;
        private readonly IFileStorageService fileService;

        public DeleteImageStatusHandler(IImageStatusRepository imageRepository, IFileStorageService fileService)
        {
            this.imageRepository = imageRepository;
            this.fileService = fileService;
        }

        public async Task<Unit> Handle(DeleteImageStatusCommand request, CancellationToken cancellationToken)
        {
            // get the entity to check existence and to take files urls from it
            var image = await imageRepository.GetByIdAsync(request.Id);
            if (image == null)
                throw new NotFoundException("The image is not exist");

            // Delete Files
            await fileService.DeleteFile(image.ImagePath);

            // Delete data
            await imageRepository.DeleteAsync(image.Id);
            return Unit.Value;
        }
    }
}
