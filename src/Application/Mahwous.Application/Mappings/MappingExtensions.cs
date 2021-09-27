//using AutoMapper;
//using Mahwous.Application.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Mahwous.Application.Mappings
//{
//    public static class MappingExtensions
//    {
//        public static PaginatedList<TDestination> PaginatedList<TDestination>(this IEnumerable<TDestination> queryable, int pageNumber, int pageSize)
//        {
//            return PaginatedList<TDestination>.Create(queryable, pageNumber, pageSize);
//        }

//        public static List<TDestination> ProjectToList<TDestination>(this IEnumerable queryable, IConfigurationProvider configuration)
//            => queryable.ProjectTo<TDestination>(configuration).ToListAsync();
//    }
//}
