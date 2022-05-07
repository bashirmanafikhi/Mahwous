//using Mahwous.Application.Interfaces;
//using Mahwous.Core.Entities;
//using Mahwous.Core.Enums;
//using Mahwous.Core.Filters;
//using Mahwous.Core.Pagination;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Mahwous.Application.BaseClasses
//{
//    public class SearchQueryBase<TModel, TFilter, TResponse> : ISearchQuery<TModel, TFilter, TResponse>
//        where TModel : BaseEntity
//        where TFilter : IFilter<TModel>
//    {
//        public PaginationDetails Pagination { get; set; }
//        public EntitySortType SortType { get; set; }
//        public TFilter Filter { get; set; }
//    }
//}
