using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using CleanApi.Infrastructure;

namespace CleanApi.Application.IntegrationTests.Common
{
    [CollectionDefinition(nameof(SliceFixture))]
    public class SliceFixtureCollection : ICollectionFixture<SliceFixture> { }
    
    public class SliceFixture
    {
        public ServiceProvider ServiceProvider { get; }
        private readonly IConfiguration _config;
        

        public SliceFixture()
        {
            
            _config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true)
                .AddEnvironmentVariables()
                .Build();
            
            var services = new ServiceCollection();
            
            services.AddSingleton(_config);
            services.AddInfrastructure(_config.GetConnectionString("DefaultConnection"));
            
            ServiceProvider = services.BuildServiceProvider();
            
        }
    }
}