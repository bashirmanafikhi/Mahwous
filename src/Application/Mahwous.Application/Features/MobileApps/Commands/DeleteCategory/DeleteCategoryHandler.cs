using Mahwous.Application.Exceptions;
using Mahwous.Core.Interfaces;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.MobileApps
{
    public class DeleteMobileAppHandler : IRequestHandler<DeleteMobileAppCommand>
    {

        private readonly IMobileAppRepository mobileAppRepository;
        private readonly IFileStorageService fileService;

        public DeleteMobileAppHandler(IMobileAppRepository mobileAppRepository, IFileStorageService fileService)
        {
            this.mobileAppRepository = mobileAppRepository;
            this.fileService = fileService;
        }

        public async Task<Unit> Handle(DeleteMobileAppCommand request, CancellationToken cancellationToken)
        {
            // get the entity to check existence and to take files urls from it
            var mobileApp = await mobileAppRepository.GetByIdAsync(request.Id);
            if (mobileApp == null)
                throw new NotFoundException("The mobileApp is not exist");

            // Delete Files
            await fileService.DeleteFile(mobileApp.CoverPath);

            // Delete data
            await mobileAppRepository.DeleteAsync(mobileApp.Id);
            return Unit.Value;
        }
    }
}
