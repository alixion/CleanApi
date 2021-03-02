using System;
using CleanApi.Application.IntegrationTests.Common;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using Xunit;
using Dapper;
using FluentAssertions;

namespace CleanApi.Application.IntegrationTests
{
    [Collection(nameof(SliceFixture))]
    public class DatabaseTests
    {
        private readonly SliceFixture _fixture;

        public DatabaseTests(SliceFixture fixture)
        {
            _fixture = fixture;
        }
        [Fact]
        public void CanConnectToLocalPostgres()
        {
            var connectionFactory = _fixture.ServiceProvider.GetService<IDbConnectionFactory>();
            using var db = connectionFactory.CreateNewConnection();
            var result = db.ExecuteScalar<int>("SELECT 1");
            result.Should().Be(1);


        }
    }
}