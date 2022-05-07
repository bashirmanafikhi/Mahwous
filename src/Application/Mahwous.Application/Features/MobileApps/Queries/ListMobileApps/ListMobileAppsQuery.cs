using Mahwous.Application.Interfaces;
using Mahwous.Application.Mappings;
using Mahwous.Core.Entities;
using Mahwous.Core.Enums;
using Mahwous.Core.Filters;
using MediatR;

namespace Mahwous.Application.Features.MobileApps
{
    public class ListMobileAppsQuery : IListQuery<MobileApp, MobileAppFilter, ListMobileAppsResponse>
    {
        public MobileAppFilter Filter { get; set; }
        public EntitySortType SortType { get; set; } = EntitySortType.Random;
    }
}
