using Mahwous.Core.Enums;
using Mahwous.Core.Filters;

namespace Mahwous.Service.ViewModels.MobileApps
{
    public class ListMobileAppsQuery : MobileAppFilter
    {
        public EntitySortType SortType { get; set; } = EntitySortType.Random;
    }
}
