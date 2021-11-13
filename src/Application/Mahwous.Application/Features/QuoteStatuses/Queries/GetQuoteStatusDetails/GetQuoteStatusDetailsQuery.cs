using MediatR;

namespace Mahwous.Application.Features.QuoteStatuses
{
    public class GetQuoteStatusDetailsQuery : IRequest<GetQuoteStatusDetailsResponse>
    {
        public int Id { get; set; }
    }
}
