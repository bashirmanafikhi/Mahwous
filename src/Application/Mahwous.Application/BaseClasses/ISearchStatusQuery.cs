using AutoMapper;
using Mahwous.Application.Mappings;
using Mahwous.Core.Entities;
using Mahwous.Core.Enums;
using Mahwous.Core.Filters;
using Mahwous.Core.Pagination;
using MediatR;

namespace Mahwous.Application.Interfaces
{
    interface ISearchStatusQuery<TModel, TFilter, TResponse> : IRequest<TResponse>//, IHaveCustomMappings
        where TModel : Status
        where TFilter : IFilter<TModel>
    {
        // Filters
        TFilter Filter { get; set; }

        // Paginations
        PaginationDetails Pagination { get; set; }

        // Sorting
        StatusSortType SortType { get; set; }

        //void IHaveCustomMappings.CreateMappings(AutoMapper.IMapperConfigurationExpression configuration)
        //{
        //    configuration.CreateMap<TFilter, TFilter>()
        //        .ForMember(x => x.Predicate, opt => opt.Ignore());
        //}
    }
}