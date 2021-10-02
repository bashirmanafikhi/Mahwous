﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Mahwous.Application.Mappings
{
    public class MapConfigurationFactory
    {
        public static MapperConfiguration GetConfigurationObject(Assembly target)
        {
            // Get all referenced assemblies
            var assemblies = GetReferencedAssembles(target);

            // Add current assembly to the assemblies list
            assemblies.Add(target);

            // Get all types of all assemblies
            var types = assemblies.SelectMany(a => a.GetExportedTypes()).ToArray();

            // Get mapper configuration
            var configuration = LoadAllMappingsAndGetMapperConfiguration(types);

            return configuration;
        }

        public static List<Assembly> GetReferencedAssembles(Assembly target, Func<AssemblyName, bool> assemblyFilter = null)
        {
            bool LoadAllFilter(AssemblyName x) => true;

            var assembliesToLoad = target.GetReferencedAssemblies()
                .Where(assemblyFilter ?? LoadAllFilter)
                .Select(Assembly.Load)
                .ToList();
            return assembliesToLoad;
        }

        private static MapperConfiguration LoadAllMappingsAndGetMapperConfiguration(IList<Type> types)
        {
            return new MapperConfiguration(config =>
            {
                config.AllowNullDestinationValues = false;

                LoadMappingFrom(config, types);
                LoadMappingTo(config, types);
                LoadCustomMappings(config, types);
            });
        }

        private static void LoadMappingTo(IMapperConfigurationExpression config, IList<Type> types)
        {
            var mapsTo = (from t in types
                          from i in t.GetInterfaces()
                          where i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapTo<>) &&
                                !t.IsAbstract &&
                                !t.IsInterface
                          select new
                          {
                              Source = t,
                              Destination = i.GetGenericArguments()[0]
                          }).ToArray();


            foreach (var map in mapsTo)
            {
                config.CreateMap(map.Source, map.Destination);
            }
        }

        private static void LoadMappingFrom(IMapperConfigurationExpression config, IList<Type> types)
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
        }

        private static void LoadCustomMappings(IMapperConfigurationExpression config, IList<Type> types)
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

    }
}