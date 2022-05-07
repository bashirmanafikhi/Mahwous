using Mahwous.Application.Mappings;
using Mahwous.Core.Entities;
using Mahwous.Core.Enums;
using Mahwous.Core.Filters;
using Mahwous.Core.Pagination;
using MediatR;

namespace Mahwous.Application.Interfaces
{
    interface IListStatusQuery<TModel, TFilter, TResponse> : IRequest<TResponse>
        where TModel : Status
        where TFilter : IFilter<TModel>
    {
        TFilter Filter { get; set; }
        StatusSortType SortType { get; set; }
    }
}