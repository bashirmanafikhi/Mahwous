using Mahwous.Application.Mappings;
using Mahwous.Core.Enums;
using Mahwous.Core.Pagination;
using MediatR;

namespace Mahwous.Application.Interfaces
{
    interface ISearchStatusQuery<TFilter, TResponse> : IMapTo<TFilter>, IRequest<TResponse>
    {
        // Paginations
        PaginationDetails Pagination { get; set; }

        // Sorting
        StatusSortType SortType { get; set; }
    }
}