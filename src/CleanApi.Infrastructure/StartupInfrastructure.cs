using System.Reflection;
using CleanApi.Application;
using CleanApi.Domain.Common;
using CleanApi.Domain.ToDoItems;
using CleanApi.Infrastructure.Data;
using CleanApi.Infrastructure.Data.EfRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.DependencyInjection;

namespace CleanApi.Infrastructure
{
    public static class StartupInfrastructure
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext(connectionString);
            services.AddScoped<IDbConnectionFactory, PostgresConnectionFactory>();
            return services;
        }

        public static IServiceCollection AddDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<CleanApiContext>(options =>
            {
                options
                    .ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>()
                    .UseNpgsql(connectionString)
                    .UseSnakeCaseNamingConvention();
            });
            services.AddScoped<IToDoRepository, ToDoRepository>();
            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
        // public static void AddApplication(this IServiceCollection services)
        // {
        //     services.AddAutoMapper(Assembly.GetExecutingAssembly());
        //     services.AddMediatR(Assembly.GetExecutingAssembly());
        // }

        
    }
}