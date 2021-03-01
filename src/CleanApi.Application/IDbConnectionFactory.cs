using System.Data;

namespace CleanApi.Application
{
    public interface IDbConnectionFactory
    {
        IDbConnection GetOpenConnection();

        IDbConnection CreateNewConnection();

        string GetConnectionString();
    }
}