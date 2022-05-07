using Mahwous.Application.Interfaces;
using Mahwous.Application.Mappings;
using Mahwous.Core.Entities;
using Mahwous.Core.Enums;
using Mahwous.Core.Filters;
using MediatR;

namespace Mahwous.Application.Features.ExternalLinks
{
    public class ListExternalLinksQuery : IListQuery<ExternalLink, ExternalLinkFilter, ListExternalLinksResponse>
    {
        public ExternalLinkFilter Filter { get; set; }
        public EntitySortType SortType { get; set; } = EntitySortType.Random;
    }
}
