using AutoMapper;
using Mahwous.Application.Behaviors;
using Mahwous.Application.Features.Posts;
using Mahwous.Core.Interfaces;
using Mahwous.Core.Interfaces.Repositories;
using Mahwous.Application.Mappings;
using Mahwous.Core.Entities;
using MahwousWeb.Persistent.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;
using System.Runtime.CompilerServices;
using Mahwous.FileStorageServices;
using Mahwous.EmailServices;

namespace Mahwous.DependencyInjection
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddMahwousServices(this IServiceCollection services)
        {
            RegisterMediator(services);
            RegisterAutoMapper(services);
            RegisterRepositories(services);
            RegisterOtherServices(services);
            return services;
        }

        private static void RegisterMediator(IServiceCollection services)
        {
            // Mediator
            services.AddMediatR(typeof(Mahwous.Application.Startup));

            // Behaviors
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ExceptionBehavior<,>));
        }

        private static void RegisterAutoMapper(IServiceCollection services)
        {
            var executingAssembly = Assembly.GetExecutingAssembly();
            var config = MapConfigurationFactory.GetConfigurationObject(executingAssembly);
            var mapper = config.CreateMapper();
            services.AddSingleton<IMapper>(sp => mapper);
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            // Repositories
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IMobileAppRepository, MobileAppRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddScoped<IVideoStatusRepository, VideoStatusRepository>();
            services.AddScoped<IImageStatusRepository, ImageStatusRepository>();
            services.AddScoped<IQuoteStatusRepository, QuoteStatusRepository>();

            // GenericRepositories
            services.AddTransient(typeof(IEntityRepository<>), typeof(EntityRepository<>));
            services.AddTransient(typeof(IStatusRepository<>), typeof(StatusRepository<>));
        }

        private static void RegisterOtherServices(IServiceCollection services)
        {
            // File Storage Services
            services.AddScoped<IFileStorageService, InAppStorageService>();

            // Email Services
            services.AddScoped<IEmailService, EmailService>();
        }
    }
}
