using Mahwous.Application.Mappings;
using Mahwous.Core.Enums;
using Mahwous.Core.Filters;
using MediatR;

namespace Mahwous.Application.Features.ExternalLinks
{
    public class ListExternalLinksQuery : ExternalLinkFilter, IMapTo<ExternalLinkFilter>, IRequest<ListExternalLinksResponse>
    {
        public EntitySortType SortType { get; set; } = EntitySortType.Random;
    }
}
