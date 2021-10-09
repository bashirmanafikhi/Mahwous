using Mahwous.Application.Mappings;
using Mahwous.Core.Filters;
using MediatR;

namespace Mahwous.Application.Features.QuoteStatuses
{
    public class ListQuoteStatusesQuery : QuoteFilter, IMapTo<QuoteFilter>, IRequest<ListQuoteStatusesResponse>
    {

    }
}
