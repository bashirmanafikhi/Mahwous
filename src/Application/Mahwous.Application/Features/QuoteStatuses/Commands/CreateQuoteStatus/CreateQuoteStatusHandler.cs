using AutoMapper;
using Mahwous.Core.Entities;
using Mahwous.Core.Interfaces;
using Mahwous.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Features.QuoteStatuses
{
    public class CreateQuoteStatusHandler : IRequestHandler<CreateQuoteStatusCommand, int>
    {

        private readonly IQuoteStatusRepository quoteRepository;
        private readonly IFileStorageService fileService;
        private readonly IMapper mapper;

        public CreateQuoteStatusHandler(IQuoteStatusRepository quoteRepository, IFileStorageService fileService, IMapper mapper)
        {
            this.quoteRepository = quoteRepository;
            this.fileService = fileService;
            this.mapper = mapper;
        }


        public async Task<int> Handle(CreateQuoteStatusCommand request, CancellationToken cancellationToken)
        {
            // Mapping
            QuoteStatus quote = mapper.Map<QuoteStatus>(request);

            // Save Files


            // Save Data
            await quoteRepository.AddAsync(quote);
            return quote.Id;
        }
    }
}
