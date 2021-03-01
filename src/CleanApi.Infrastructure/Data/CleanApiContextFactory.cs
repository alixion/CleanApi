using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CleanApi.Infrastructure.Data
{
    // For Migrations
    public class CleanApiContextFactory:IDesignTimeDbContextFactory<CleanApiContext>
    {
        public CleanApiContext CreateDbContext(string[] args)
        {
            const string connectionString = "Host=localhost;Database=CleanApiDb;Uid=postgres;Pwd=Parola.1";
            var dbContextBuilder = new DbContextOptionsBuilder<CleanApiContext>();
            dbContextBuilder
                .ReplaceService<IValueConverterSelector,StronglyTypedIdValueConverterSelector>()
                .UseNpgsql(connectionString)
                .UseSnakeCaseNamingConvention();

            return new CleanApiContext(dbContextBuilder.Options);
        }
    }
}