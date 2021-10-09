using Mahwous.Application.Mappings;
using Mahwous.Core.Enums;
using Mahwous.Core.Filters;
using Mahwous.Core.Pagination;
using MediatR;

namespace Mahwous.Application.Interfaces
{
    interface ISearchStatusQuery<TFilter, TResponse> : IMapTo<TFilter>, IRequest<TResponse>
    {
        // Paginations
        public PaginationDetails Pagination { get; set; }

        // Sorting
        public StatusSortType SortType { get; set; }
    }
}