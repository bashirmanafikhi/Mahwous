using Mahwous.Application.Mappings;
using Mahwous.Core.Entities;

namespace Mahwous.Application.Features.QuoteStatuses
{
    public class GetRandomQuoteStatusResponse : GetQuoteStatusDetailsResponse, IMapFrom<QuoteStatus>
    {

    }
}
