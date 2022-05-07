using Mahwous.Application.Interfaces;
using Mahwous.Application.Mappings;
using Mahwous.Core.Entities;
using Mahwous.Core.Enums;
using Mahwous.Core.Filters;
using MediatR;

namespace Mahwous.Application.Features.QuoteStatuses
{
    public class ListQuoteStatusesQuery : IListStatusQuery<QuoteStatus, QuoteFilter, ListQuoteStatusesResponse>
    {
        public QuoteFilter Filter { get; set; }
        public StatusSortType SortType { get; set; } = StatusSortType.Random;
    }
}
