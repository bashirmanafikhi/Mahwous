using AutoMapper;
using Mahwous.Application.Exceptions;
using Mahwous.Application.Extensions;
using Mahwous.Core.Entities;
using Mahwous.Core.Interfaces;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.ExternalLinks
{
    public class UpdateExternalLinkHandler : IRequestHandler<UpdateExternalLinkCommand, int>
    {

        private readonly IExternalLinkRepository externalLinkRepository;
        private readonly IFileStorageService fileService;
        private readonly IMapper mapper;

        public UpdateExternalLinkHandler(IExternalLinkRepository externalLinkRepository, IFileStorageService fileService, IMapper mapper)
        {
            this.externalLinkRepository = externalLinkRepository;
            this.fileService = fileService;
            this.mapper = mapper;
        }


        public async Task<int> Handle(UpdateExternalLinkCommand request, CancellationToken cancellationToken)
        {
            // get the original object to check existence and to take files urls from it
            var oldExternalLink = await externalLinkRepository.GetByIdAsync(request.Id);
            if (oldExternalLink == null)
                throw new NotFoundException("The externalLink is not exist");

            // Mapping
            ExternalLink newExternalLink = mapper.Map<ExternalLink>(request);

            // Map the old files urls
            newExternalLink.CoverPath = oldExternalLink.CoverPath;

            // Save Files if a new file comes
            if (request.Cover != null && request.Cover.Length > 0)
            {
                var coverFile = request.Cover.ToMemoryStream();
                newExternalLink.CoverPath = await fileService.EditFile(newExternalLink.CoverPath, coverFile, Core.Enums.FileType.Image);
            }

            // Save Data
            await externalLinkRepository.UpdateAsync(newExternalLink);
            return newExternalLink.Id;
        }
    }
}
