using System.Reflection;
using CleanApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.DependencyInjection;

namespace CleanApi.Infrastructure
{
    public static class StartupInfrastructure
    {
        public static void AddDbContext(this IServiceCollection services, string connectionString) =>
            services.AddDbContext<CleanApiContext>(options =>
            {
                options
                    .ReplaceService<IValueConverterSelector,StronglyTypedIdValueConverterSelector>()
                    .UseNpgsql(connectionString)
                    .UseSnakeCaseNamingConvention();
            });

        // public static void AddApplication(this IServiceCollection services)
        // {
        //     services.AddAutoMapper(Assembly.GetExecutingAssembly());
        //     services.AddMediatR(Assembly.GetExecutingAssembly());
        // }

        
    }
}