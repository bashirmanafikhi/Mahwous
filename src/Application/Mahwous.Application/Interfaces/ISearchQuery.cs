using Mahwous.Application.Mappings;
using Mahwous.Core.Pagination;
using MediatR;

namespace Mahwous.Application.Interfaces
{
    interface ISearchQuery<TFilter, TResponse> : IMapTo<TFilter>, IRequest<TResponse>
    {
        // Paginations
        public PaginationDetails Pagination { get; set; }
    }
}