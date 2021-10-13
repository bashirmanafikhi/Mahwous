using Mahwous.Core.Enums;
using Mahwous.Core.Filters;

namespace Mahwous.Service.ViewModels.VideoStatuses
{
    public class ListVideoStatusesQuery : VideoFilter
    {
        public StatusSortType SortType { get; set; } = StatusSortType.Random;
    }
}
