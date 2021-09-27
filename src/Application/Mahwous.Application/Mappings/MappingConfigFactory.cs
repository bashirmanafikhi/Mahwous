using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Mahwous.Application.Mappings
{
    public class MapConfigurationFactory
    {
        // how to use
        //Set up code for automapper configuration 
        //MapConfigurationFactory.Scan<Startup>();
        public static void Scan<TType>(Func<AssemblyName, bool> assemblyFilter = null)
        {
            var target = typeof(TType).Assembly;

            bool LoadAllFilter(AssemblyName x) => true;

            var assembliesToLoad = target.GetReferencedAssemblies()
                .Where(assemblyFilter ?? LoadAllFilter)
                .Select(Assembly.Load)
                .ToList();

            assembliesToLoad.Add(target);

            LoadMapsFromAssemblies(assembliesToLoad.ToArray());
        }

        public static void LoadMapsFromAssemblies(params Assembly[] assemblies)
        {
            var types = assemblies.SelectMany(a => a.GetExportedTypes()).ToArray();
            LoadAllMappings(types);
        }


        public static void LoadAllMappings(IList<Type> types)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullDestinationValues = false;

                LoadStandardMappings(cfg, types);
                LoadCustomMappings(cfg, types);
            });
        }


        public static void LoadCustomMappings(IMapperConfigurationExpression config, IList<Type> types)
        {
            var instancesToMap = (from t in types
                                  from i in t.GetInterfaces()
                                  where typeof(IHaveCustomMappings).IsAssignableFrom(t) &&
                                        !t.IsAbstract &&
                                        !t.IsInterface
                                  select (IHaveCustomMappings)Activator.CreateInstance(t)).ToArray();


            foreach (var map in instancesToMap)
            {
                map.CreateMappings(config);
            }
        }

        public static void LoadStandardMappings(IMapperConfigurationExpression config, IList<Type> types)
        {
            var mapsFrom = (from t in types
                            from i in t.GetInterfaces()
                            where i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>) &&
                                  !t.IsAbstract &&
                                  !t.IsInterface
                            select new
                            {
                                Source = i.GetGenericArguments()[0],
                                Destination = t
                            }).ToArray();


            foreach (var map in mapsFrom)
            {
                config.CreateMap(map.Source, map.Destination);
            }


            var mapsTo = (from t in types
                          from i in t.GetInterfaces()
                          where i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapTo<>) &&
                                !t.IsAbstract &&
                                !t.IsInterface
                          select new
                          {
                              Source = i.GetGenericArguments()[0],
                              Destination = t
                          }).ToArray();


            foreach (var map in mapsTo)
            {
                config.CreateMap(map.Source, map.Destination);
            }
        }


        // Bashir


        public static void Scan(Assembly target, Func<AssemblyName, bool> assemblyFilter = null)
        {
            bool LoadAllFilter(AssemblyName x) => true;

            var assembliesToLoad = target.GetReferencedAssemblies()
                .Where(assemblyFilter ?? LoadAllFilter)
                .Select(Assembly.Load)
                .ToList();

            assembliesToLoad.Add(target);

            LoadMapsFromAssemblies(assembliesToLoad.ToArray());
        }
    }
}