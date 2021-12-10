using Mahwous.Core.Exceptions;
using Mahwous.Core.Exceptions;
using Mahwous.Core.Interfaces;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.ExternalLinks
{
    public class DeleteExternalLinkHandler : IRequestHandler<DeleteExternalLinkCommand>
    {

        private readonly IExternalLinkRepository externalLinkRepository;
        private readonly IFileStorageService fileService;

        public DeleteExternalLinkHandler(IExternalLinkRepository externalLinkRepository, IFileStorageService fileService)
        {
            this.externalLinkRepository = externalLinkRepository;
            this.fileService = fileService;
        }

        public async Task<Unit> Handle(DeleteExternalLinkCommand request, CancellationToken cancellationToken)
        {
            // get the entity to check existence and to take files urls from it
            var externalLink = await externalLinkRepository.GetByIdAsync(request.Id);
            if (externalLink == null)
                throw new NotFoundException("The externalLink is not exist");

            // Delete Files
            await fileService.DeleteFile(externalLink.CoverPath);

            // Delete data
            await externalLinkRepository.DeleteAsync(externalLink.Id);
            return Unit.Value;
        }
    }
}
