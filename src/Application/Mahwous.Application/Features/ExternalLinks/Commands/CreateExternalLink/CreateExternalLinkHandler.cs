using AutoMapper;
using Mahwous.Application.Extensions;
using Mahwous.Core.Entities;
using Mahwous.Core.Interfaces;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.ExternalLinks
{
    public class CreateExternalLinkHandler : IRequestHandler<CreateExternalLinkCommand, int>
    {

        private readonly IExternalLinkRepository externalLinkRepository;
        private readonly IFileStorageService fileService;
        private readonly IMapper mapper;

        public CreateExternalLinkHandler(IExternalLinkRepository externalLinkRepository, IFileStorageService fileService, IMapper mapper)
        {
            this.externalLinkRepository = externalLinkRepository;
            this.fileService = fileService;
            this.mapper = mapper;
        }


        public async Task<int> Handle(CreateExternalLinkCommand request, CancellationToken cancellationToken)
        {
            // Mapping
            ExternalLink externalLink = mapper.Map<ExternalLink>(request);

            // Save Files
            var coverFile = request.Cover.ToMemoryStream();
            externalLink.CoverPath = await fileService.SaveFile(coverFile, Core.Enums.FileType.Image);

            // Save Data
            await externalLinkRepository.AddAsync(externalLink);
            return externalLink.Id;
        }
    }
}
