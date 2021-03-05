using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using CleanApi.Infrastructure;
using CleanApi.Infrastructure.Data;
using MediatR;

namespace CleanApi.Application.IntegrationTests.Common
{
    [CollectionDefinition(nameof(SliceFixture))]
    public class SliceFixtureCollection : ICollectionFixture<SliceFixture> { }
    
    public class SliceFixture:IDisposable
    {
        public IServiceScope Scope { get; }
        public ServiceProvider ServiceProvider { get; }
        public CleanApiContext Context { get;  }
        private readonly IConfiguration _config;
        
        

        public SliceFixture()
        {
           
            _config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true)
                .AddEnvironmentVariables()
                .Build();
            
            var services = new ServiceCollection();
            services.AddLogging();
            services.AddSingleton(_config);
            services.AddApplication();
            services.AddInfrastructure(_config.GetConnectionString("DefaultConnection"));
            
            ServiceProvider = services.BuildServiceProvider();
            
            Scope = CreateScope();
            Context = Scope.ServiceProvider.GetService<CleanApiContext>();
        }



        public async Task<TEntity> FindAsync<TEntity, TKey>(TKey id)
            where TEntity : class
        {
            return await Context.FindAsync<TEntity>(id);
        }
        public async Task AddAsync<TEntity>(TEntity entity)
            where TEntity : class
        {
            Context.Add(entity);
            await Context.SaveChangesAsync();
        }
        
        public async Task RemoveAsync<TEntity>(TEntity entity)
            where TEntity : class
        {
            Context.Remove(entity);
            await Context.SaveChangesAsync();
        }
        public async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
        {
            var mediatr = Scope.ServiceProvider.GetService<IMediator>();
            return await mediatr.Send(request);
        }
        
        
        public IServiceScope CreateScope()
        {
            var serviceFactory = ServiceProvider.GetService <IServiceScopeFactory>();
            return serviceFactory.CreateScope();
        }

        public void Dispose()
        {
            Scope?.Dispose();
            ServiceProvider?.Dispose();
        }
    }
}