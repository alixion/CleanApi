using System;
using System.Data;
using CleanApi.Application;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace CleanApi.Infrastructure.Data
{
    public class PostgresConnectionFactory:IDbConnectionFactory,IDisposable
    {
        private IDbConnection _connection;
        private readonly string _connectionString;

        public PostgresConnectionFactory(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public IDbConnection GetOpenConnection()
        {
            if (_connection==null || _connection.State!=ConnectionState.Open)
            {
                _connection = new NpgsqlConnection(_connectionString);
                _connection.Open();
            }

            return _connection;
        }

        public IDbConnection CreateNewConnection()
        {
            var connection = new NpgsqlConnection(_connectionString);
            connection.Open();

            return connection;
        }

        public string GetConnectionString()
        {
            return _connectionString;
        }

        public void Dispose()
        {
            _connection?.Dispose();
        }
    }
}