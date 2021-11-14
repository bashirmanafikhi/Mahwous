using Mahwous.Application.Mappings;
using Mahwous.Core.Entities;

namespace Mahwous.Application.Features.ExternalLinks
{
    public class GetRandomExternalLinkResponse : GetExternalLinkDetailsResponse, IMapFrom<ExternalLink>
    {

    }
}
