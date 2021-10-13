using Mahwous.Core.Enums;
using Mahwous.Core.Filters;

namespace Mahwous.Service.ViewModels.ImageStatuses
{
    public class ListImageStatusesQuery : ImageFilter
    {
        public StatusSortType SortType { get; set; } = StatusSortType.Random;
    }
}
