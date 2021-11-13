using MediatR;

namespace Mahwous.Application.Features.QuoteStatuses
{
    public class DeleteQuoteStatusCommand : IRequest
    {
        public int Id { get; set; }
    }
}
