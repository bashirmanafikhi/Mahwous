using AutoMapper;
using Mahwous.Application.Exceptions;
using Mahwous.Application.Extensions;
using Mahwous.Core.Entities;
using Mahwous.Core.Interfaces;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.MobileApps
{
    public class UpdateMobileAppHandler : IRequestHandler<UpdateMobileAppCommand, int>
    {

        private readonly IMobileAppRepository mobileAppRepository;
        private readonly IFileStorageService fileService;
        private readonly IMapper mapper;

        public UpdateMobileAppHandler(IMobileAppRepository mobileAppRepository, IFileStorageService fileService, IMapper mapper)
        {
            this.mobileAppRepository = mobileAppRepository;
            this.fileService = fileService;
            this.mapper = mapper;
        }


        public async Task<int> Handle(UpdateMobileAppCommand request, CancellationToken cancellationToken)
        {
            // get the original object to check existence and to take files urls from it
            var oldMobileApp = await mobileAppRepository.GetByIdAsync(request.Id);
            if (oldMobileApp == null)
                throw new NotFoundException("The mobileApp is not exist");

            // Mapping
            MobileApp newMobileApp = mapper.Map<MobileApp>(request);

            // Map the old files urls
            newMobileApp.CoverPath = oldMobileApp.CoverPath;

            // Save Files if a new file comes
            if (request.Cover != null && request.Cover.Length > 0)
            {
                var coverFile = request.Cover.ToMemoryStream();
                newMobileApp.CoverPath = await fileService.EditFile(newMobileApp.CoverPath, coverFile, Core.Enums.FileType.Image);
            }

            // Save Data
            await mobileAppRepository.UpdateAsync(newMobileApp);
            return newMobileApp.Id;
        }
    }
}
