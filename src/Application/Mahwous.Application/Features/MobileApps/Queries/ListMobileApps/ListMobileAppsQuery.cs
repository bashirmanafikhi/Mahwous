using Mahwous.Application.Mappings;
using Mahwous.Core.Enums;
using Mahwous.Core.Filters;
using MediatR;

namespace Mahwous.Application.Features.MobileApps
{
    public class ListMobileAppsQuery : MobileAppFilter, IMapTo<MobileAppFilter>, IRequest<ListMobileAppsResponse>
    {
        public EntitySortType SortType { get; set; } = EntitySortType.Random;
    }
}
