using AutoMapper;
using FluentValidation;
using Mahwous.Application.Behaviors;
using Mahwous.Application.Mappings;
using Mahwous.Core.Interfaces;
using Mahwous.Core.Interfaces.Repositories;
using Mahwous.EmailServices;
using Mahwous.FileStorageServices;
using Mahwous.Persistence.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Mahwous.DependencyInjection
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddMahwousServices(this IServiceCollection services)
        {
            RegisterValidators(services);
            RegisterMediator(services);
            RegisterAutoMapper(services);
            RegisterRepositories(services);
            RegisterSignalR(services);
            RegisterOtherServices(services);
            return services;
        }

        private static void RegisterSignalR(IServiceCollection services)
        {
            services.AddSignalR();
        }

        private static void RegisterValidators(IServiceCollection services)
        {
            // For all the validators in the application project, register them with dependency injection as scoped
            services.AddValidatorsFromAssemblyContaining<Application.Startup>();
        }

        private static void RegisterMediator(IServiceCollection services)
        {
            // Mediator
            services.AddMediatR(typeof(Mahwous.Application.Startup));

            // Behaviors
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ExceptionBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
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
            services.AddTransient(typeof(IEntityRepository<,>), typeof(EntityRepository<,>));
            services.AddTransient(typeof(IStatusRepository<,>), typeof(StatusRepository<,>));
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
