using Mahwous.Application.Mappings;
using Mahwous.Core.Enums;
using Mahwous.Core.Pagination;
using MediatR;

namespace Mahwous.Application.Interfaces
{
    interface ISearchQuery<TFilter, TResponse> : IMapTo<TFilter>, IRequest<TResponse>
    {
        // Paginations
        PaginationDetails Pagination { get; set; }

        // Sorting
        EntitySortType SortType { get; set; }
    }
}