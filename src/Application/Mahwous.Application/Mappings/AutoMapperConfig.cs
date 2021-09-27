//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
//using AutoMapper;


//// Execute this method on ApplicationStart
////[assembly: PreApplicationStartMethod(typeof(AutoMapperConfig), "Execute")]

//namespace Mahwous.Application.Mappings
//{
//    public class AutoMapperConfig
//    {
//        /// <summary>
//        /// Initialize Mapping process by finding all types that needs 
//        /// to be mapped
//        /// </summary>
//        public static void Execute()
//        {
//            var types = Assembly.GetExecutingAssembly().GetExportedTypes();

//            var config = new MapperConfiguration(cfg =>
//            {
//                cfg.AllowNullDestinationValues = false;

//                RegisterStandardMappings(cfg, types);
//                RegisterReverseMappings(cfg, types);
//                ReverseCustomMappings(cfg, types);
//            });

//            var mapper = config.CreateMapper();





//            Mapper.Initialize(
//                cfg =>
//                {
//                    LoadStandardMappings(cfg, types);
//                    LoadCustomMappings(cfg, types);
//                });
//        }

//        /// <summary>
//        /// Load all types that implement interface <see cref="IMapFrom{T}"/>
//        /// and create a map between {T} and them
//        /// </summary>
//        /// <param name="types"></param>
//        private static void RegisterStandardMappings(IMapperConfigurationExpression cfg, IEnumerable<Type> types)
//        {
//            var maps = (from t in types
//                        from i in t.GetInterfaces()
//                        where i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)
//                              && !t.IsAbstract
//                              && !t.IsInterface
//                        select new
//                        {
//                            Source = i.GetGenericArguments()[0],
//                            Destination = t
//                        }).ToArray();

//            foreach (var map in maps)
//            {
//                map.CreateMap(map.Source, map.Destination);
//            }
//        }

//        /// <summary>
//        /// Load all types that implement interface <see cref="IMapFrom{T}"/>
//        /// and create a map between them and {T}
//        /// </summary>
//        /// <param name="types"></param>
//        private static void RegisterReverseMappings(IMapperConfigurationExpression cfg, IEnumerable<Type> types)
//        {
//            var maps = (from t in types
//                        from i in t.GetInterfaces()
//                        where i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapTo<>)
//                              && !t.IsAbstract
//                              && !t.IsInterface
//                        select new
//                        {
//                            Source = t,
//                            Destination = i.GetGenericArguments()[0]
//                        }).ToArray();

//            foreach (var map in maps)
//            {
//                Mapper.CreateMap(map.Source, map.Destination);
//            }
//        }

//        /// <summary>
//        /// Load all types that implement interface <see cref="IHaveCustomMappings"/>
//        /// and register their mapping
//        /// </summary>
//        /// <param name="types"></param>
//        private static void ReverseCustomMappings(IMapperConfigurationExpression cfg, IEnumerable<Type> types)
//        {
//            var maps = (from t in types
//                        from i in t.GetInterfaces()
//                        where typeof(IHaveCustomMappings).IsAssignableFrom(t)
//                              && !t.IsAbstract
//                              && !t.IsInterface
//                        select (IHaveCustomMappings)Activator.CreateInstance(t)).ToArray();

//            foreach (var map in maps)
//            {
//                map.CreateMappings(Mapper.Configuration);
//            }
//        }
//    }
//}