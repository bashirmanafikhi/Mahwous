using Mahwous.Core.Enums;
using Mahwous.Core.Filters;

namespace Mahwous.Service.ViewModels.QuoteStatuses
{
    public class ListQuoteStatusesQuery : QuoteFilter
    {
        public StatusSortType SortType { get; set; } = StatusSortType.Random;
    }
}
