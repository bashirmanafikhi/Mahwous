using AutoMapper;
using Mahwous.Application.Extensions;
using Mahwous.Core.Entities;
using Mahwous.Core.Interfaces;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.MobileApps
{
    public class CreateMobileAppHandler : IRequestHandler<CreateMobileAppCommand, int>
    {

        private readonly IMobileAppRepository mobileAppRepository;
        private readonly IFileStorageService fileService;
        private readonly IMapper mapper;

        public CreateMobileAppHandler(IMobileAppRepository mobileAppRepository, IFileStorageService fileService, IMapper mapper)
        {
            this.mobileAppRepository = mobileAppRepository;
            this.fileService = fileService;
            this.mapper = mapper;
        }


        public async Task<int> Handle(CreateMobileAppCommand request, CancellationToken cancellationToken)
        {
            // Mapping
            MobileApp mobileApp = mapper.Map<MobileApp>(request);

            // Save Files
            var coverFile = request.cover.ToMemoryStream();
            mobileApp.CoverPath = await fileService.SaveFile(coverFile, Core.Enums.FileType.Image);

            // Save Data
            await mobileAppRepository.AddAsync(mobileApp);
            return mobileApp.Id;
        }
    }
}
