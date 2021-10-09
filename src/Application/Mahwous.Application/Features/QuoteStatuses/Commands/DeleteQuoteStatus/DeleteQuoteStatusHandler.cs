using Mahwous.Application.Exceptions;
using Mahwous.Core.Interfaces;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.QuoteStatuses
{
    public class DeleteQuoteStatusHandler : IRequestHandler<DeleteQuoteStatusCommand>
    {

        private readonly IQuoteStatusRepository quoteRepository;
        private readonly IFileStorageService fileService;

        public DeleteQuoteStatusHandler(IQuoteStatusRepository quoteRepository, IFileStorageService fileService)
        {
            this.quoteRepository = quoteRepository;
            this.fileService = fileService;
        }

        public async Task<Unit> Handle(DeleteQuoteStatusCommand request, CancellationToken cancellationToken)
        {
            // check existence
            var exist = await quoteRepository.AnyAsync(x => x.Id == request.Id);
            if (!exist)
                throw new NotFoundException("The quote is not exist");

            // Delete Files


            // Delete data
            await quoteRepository.DeleteAsync(request.Id);
            return Unit.Value;
        }
    }
}
