using AutoMapper;
using Mahwous.Application.Exceptions;
using Mahwous.Core.Entities;
using Mahwous.Core.Interfaces;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.QuoteStatuses
{
    public class UpdateQuoteStatusHandler : IRequestHandler<UpdateQuoteStatusCommand, int>
    {

        private readonly IQuoteStatusRepository quoteRepository;
        private readonly IFileStorageService fileService;
        private readonly IMapper mapper;

        public UpdateQuoteStatusHandler(IQuoteStatusRepository quoteRepository, IFileStorageService fileService, IMapper mapper)
        {
            this.quoteRepository = quoteRepository;
            this.fileService = fileService;
            this.mapper = mapper;
        }


        public async Task<int> Handle(UpdateQuoteStatusCommand request, CancellationToken cancellationToken)
        {
            // check existence
            var exist = await quoteRepository.AnyAsync(x => x.Id == request.Id);
            if (!exist)
                throw new NotFoundException("The quote is not exist");

            // Mapping
            QuoteStatus quote = mapper.Map<QuoteStatus>(request);

            // Save Data
            await quoteRepository.UpdateAsync(quote);
            return quote.Id;
        }
    }
}
